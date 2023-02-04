using MicroservicesToDocker.Data;

namespace MicroservicesToDocker.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<int?> Add(string type);
        Task<EntityModifyState> Remove(int id);
        Task<EntityModifyState> Update(int id, string type);
    }
}
