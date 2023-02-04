using MicroservicesToDocker.Data;
using MicroservicesToDocker.Repositories.Interfaces;
using MicroservicesToDocker.Services.Interfaces;
using MicroservicesToDocker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesToDocker.Repositories
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CatalogTypeRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int?> Add(string type)
        {
            var result = await _dbContext.CatalogTypes.AddAsync(new CatalogType { Type = type });

            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<EntityModifyState> Remove(int id)
        {
            bool exists = await _dbContext.CatalogTypes.AnyAsync(ct => ct.Id == id);

            if (!exists)
            {
                return EntityModifyState.NotFound;
            }

            var result = _dbContext.CatalogTypes.Remove(new CatalogType { Id = id });
            await _dbContext.SaveChangesAsync();

            return EntityModifyState.Deleted;
        }

        public async Task<EntityModifyState> Update(int id, string type)
        {
            bool exists = await _dbContext.CatalogTypes.AnyAsync(ct => ct.Id == id);

            if (!exists)
            {
                return EntityModifyState.NotFound;
            }

            var result = _dbContext.CatalogTypes.Update(new CatalogType { Id = id, Type = type });

            if (result is null)
            {
                return EntityModifyState.NotUpdated;
            }

            await _dbContext.SaveChangesAsync();

            return EntityModifyState.Updated;
        }
    }
}
