using MicroservicesToDocker.Data;

namespace MicroservicesToDocker.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<int?> AddAsync(string brand);
        Task<EntityModifyState> RemoveAsync(int id);
        Task<EntityModifyState> UpdateAsync(int id, string brand);
    }
}
