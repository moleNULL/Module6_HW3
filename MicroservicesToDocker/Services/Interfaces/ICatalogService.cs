using MicroservicesToDocker.Models.Dtos;
using MicroservicesToDocker.Models.Response;

namespace MicroservicesToDocker.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    Task<CatalogItemDto?> GetItemById(int id);
    Task<List<CatalogItemDto>?> GetItemsByBrand(string brand);
    Task<List<CatalogItemDto>?> GetItemsByTypeAsync(string type);
}