using MicroservicesToDocker.Data;
using MicroservicesToDocker.Repositories.Interfaces;
using MicroservicesToDocker.Services.Interfaces;

namespace MicroservicesToDocker.Services.Implementations
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

        public Task<int?> AddAsync(string type)
        {
            return ExecuteSafeAsync(()
                => _catalogTypeRepository.AddAsync(type));
        }

        public Task<EntityModifyState> RemoveAsync(int id)
        {
            return ExecuteSafeAsync(()
                => _catalogTypeRepository.RemoveAsync(id));
        }

        public Task<EntityModifyState> UpdateAsync(int id, string type)
        {
            return ExecuteSafeAsync(()
                => _catalogTypeRepository.UpdateAsync(id, type));
        }
    }
}
