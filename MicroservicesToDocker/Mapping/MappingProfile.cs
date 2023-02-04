using AutoMapper;
using MicroservicesToDocker.Data.Entities;
using MicroservicesToDocker.Models.Dtos;

namespace MicroservicesToDocker.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItemEntity, CatalogItemDto>()
            .ForMember("PictureUrl", opt
                => opt.MapFrom<CatalogItemPictureResolver, string>(c => c.PictureFileName));
        CreateMap<CatalogBrandEntity, CatalogBrandDto>();
        CreateMap<CatalogTypeEntity, CatalogTypeDto>();
    }
}