using MicroservicesToDocker.Data;
using MicroservicesToDocker.Repositories.Interfaces;
using MicroservicesToDocker.Services.Interfaces;

namespace MicroservicesToDocker.Services
{
    public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
    {
        private readonly ICatalogTypeRepository _catalogTypeRepository;

        public CatalogTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogTypeRepository catalogTypeRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogTypeRepository = catalogTypeRepository;
        }

        public Task<int?> Add(string type)
        {
            return ExecuteSafeAsync(()
                => _catalogTypeRepository.Add(type));
        }

        public Task<EntityModifyState> Remove(int id)
        {
            return ExecuteSafeAsync(()
                => _catalogTypeRepository.Remove(id));
        }

        public Task<EntityModifyState> Update(int id, string type)
        {
            return ExecuteSafeAsync(()
                => _catalogTypeRepository.Update(id, type));
        }
    }
}
