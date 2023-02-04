using MicroservicesToDocker.Data;

namespace MicroservicesToDocker.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<int?> Add(string brand);
        Task<EntityModifyState> Remove(int id);
        Task<EntityModifyState> Update(int id, string brand);
    }
}
