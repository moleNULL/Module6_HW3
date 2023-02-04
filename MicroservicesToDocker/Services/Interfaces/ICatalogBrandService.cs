using MicroservicesToDocker.Data;

namespace MicroservicesToDocker.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<int?> Add(string brand);
        Task<EntityModifyState> Remove(int id);
        Task<EntityModifyState> Update(int id, string brand);
    }
}
