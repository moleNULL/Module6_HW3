using MicroservicesToDocker.Data;
using MicroservicesToDocker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesToDocker.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize);
    Task<CatalogItem?> GetByIdAsync(int id);
    Task<List<CatalogItem>?> GetByBrandAsync(string brand);
    Task<List<CatalogItem>?> GetByTypeAsync(string type);
    Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<EntityModifyState> Remove(int id);
    Task<EntityModifyState> Update(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
}