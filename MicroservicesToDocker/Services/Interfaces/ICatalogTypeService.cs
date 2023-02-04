using MicroservicesToDocker.Data;

namespace MicroservicesToDocker.Services.Interfaces
{
    public interface ICatalogTypeService
    {
        Task<int?> Add(string type);
        Task<EntityModifyState> Remove(int id);
        Task<EntityModifyState> Update(int id, string type);
    }
}
