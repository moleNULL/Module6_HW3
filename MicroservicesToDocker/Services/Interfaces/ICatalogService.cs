using MicroservicesToDocker.Models.Dtos;
using MicroservicesToDocker.Models.Response;

namespace MicroservicesToDocker.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    Task<CatalogItemDto?> GetItemByIdAsync(int id);
    Task<List<CatalogItemDto>?> GetItemsByBrandAsync(string brand);
    Task<List<CatalogItemDto>?> GetItemsByTypeAsync(string type);
    Task<List<CatalogBrandDto>> GetBrandsAsync();
    Task<List<CatalogTypeDto>> GetTypesAsync();
}