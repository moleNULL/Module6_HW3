using AutoMapper;
using MicroservicesToDocker.Configurations;
using MicroservicesToDocker.Data.Entities;
using MicroservicesToDocker.Models.Dtos;
using Microsoft.Extensions.Options;

namespace MicroservicesToDocker.Mapping;

public class CatalogItemPictureResolver : IMemberValueResolver<CatalogItemEntity, CatalogItemDto, string, object>
{
    private readonly CatalogConfig _config;

    public CatalogItemPictureResolver(IOptionsSnapshot<CatalogConfig> config)
    {
        _config = config.Value;
    }

    public object Resolve(CatalogItemEntity source, CatalogItemDto destination, string sourceMember, object destMember, ResolutionContext context)
    {
        return $"{_config.Host}/{_config.ImgUrl}/{sourceMember}";
    }
}