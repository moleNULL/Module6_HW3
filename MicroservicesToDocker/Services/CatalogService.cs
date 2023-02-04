using AutoMapper;
using MicroservicesToDocker.Configurations;
using MicroservicesToDocker.Data;
using MicroservicesToDocker.Data.Entities;
using MicroservicesToDocker.Models.Dtos;
using MicroservicesToDocker.Models.Response;
using MicroservicesToDocker.Repositories.Interfaces;
using MicroservicesToDocker.Services.Interfaces;

namespace MicroservicesToDocker.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByPageAsync(pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<CatalogItemDto?> GetItemByIdAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByIdAsync(id);

            var resultDto = _mapper.Map(result, typeof(CatalogItemEntity), typeof(CatalogItemDto));

            return (CatalogItemDto)resultDto;
        });
    }

    public async Task<List<CatalogItemDto>?> GetItemsByBrandAsync(string brand)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByBrandAsync(brand);

            if (result is null)
            {
                return null;
            }

            var resultDto = _mapper.Map(result, typeof(List<CatalogItemEntity>), typeof(List<CatalogItemDto>));

            return (List<CatalogItemDto>)resultDto;
        });
    }

    public async Task<List<CatalogItemDto>?> GetItemsByTypeAsync(string type)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByTypeAsync(type);

            if (result is null)
            {
                return null;
            }

            var resultDto = _mapper.Map(result, typeof(List<CatalogItemEntity>), typeof(List<CatalogItemDto>));

            return (List<CatalogItemDto>)resultDto;
        });
    }

    public async Task<List<CatalogBrandDto>> GetBrandsAsync()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetBrandsAsync();

            var resultDto = _mapper.Map(result, typeof(List<CatalogBrandEntity>), typeof(List<CatalogBrandDto>));

            return (List<CatalogBrandDto>)resultDto;
        });
    }

    public async Task<List<CatalogTypeDto>> GetTypesAsync()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetTypesAsync();

            var resultDto = _mapper.Map(result, typeof(List<CatalogTypeEntity>), typeof(List<CatalogTypeDto>));

            return (List<CatalogTypeDto>)resultDto;
        });
    }
}