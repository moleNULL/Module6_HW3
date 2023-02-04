using MicroservicesToDocker.Data;
using MicroservicesToDocker.Data.Entities;
using MicroservicesToDocker.Repositories.Interfaces;
using MicroservicesToDocker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesToDocker.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CatalogItemRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogItems
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new CatalogItem
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<EntityModifyState> Remove(int id)
    {
        bool exists = await _dbContext.CatalogItems.AnyAsync(ci => ci.Id == id);

        if (!exists)
        {
            return EntityModifyState.NotFound;
        }

        var result = _dbContext.Remove(new CatalogItem { Id = id });
        await _dbContext.SaveChangesAsync();

        return EntityModifyState.Deleted;
    }

    public async Task<EntityModifyState> Update(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        bool exists = await _dbContext.CatalogItems.AnyAsync(ci => ci.Id == id);

        if (!exists)
        {
            return EntityModifyState.NotFound;
        }

        var result = _dbContext.CatalogItems.Update(new CatalogItem
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price
        });

        if (result is null)
        {
            return EntityModifyState.NotUpdated;
        }

        await _dbContext.SaveChangesAsync();

        return EntityModifyState.Updated;
    }
}