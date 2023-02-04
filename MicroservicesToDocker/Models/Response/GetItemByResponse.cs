using MicroservicesToDocker.Models.Dtos;

namespace MicroservicesToDocker.Models.Response
{
    // One class for GetItemById, GetItemByBrand, GetItemByType, GetItemByBrands, GetItemByTypes
    public class GetItemByResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = null!;
        public CatalogTypeDto? CatalogType { get; set; }
        public CatalogBrandDto? CatalogBrand { get; set; }
        public int AvailableStock { get; set; }
    }
}
