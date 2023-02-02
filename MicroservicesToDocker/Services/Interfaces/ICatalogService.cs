using MicroservicesToDocker.Models.Dtos;
using MicroservicesToDocker.Models.Response;

namespace MicroservicesToDocker.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);
}