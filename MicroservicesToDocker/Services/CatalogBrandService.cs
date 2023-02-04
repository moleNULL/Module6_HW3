using MicroservicesToDocker.Data;
using MicroservicesToDocker.Repositories.Interfaces;
using MicroservicesToDocker.Services.Interfaces;

namespace MicroservicesToDocker.Services
{
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;

        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogBrandRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogBrandRepository = catalogBrandRepository;
        }

        public Task<int?> AddAsync(string brand)
        {
            return ExecuteSafeAsync(()
                => _catalogBrandRepository.AddAsync(brand));
        }

        public Task<EntityModifyState> RemoveAsync(int id)
        {
            return ExecuteSafeAsync(()
                => _catalogBrandRepository.RemoveAsync(id));
        }

        public Task<EntityModifyState> UpdateAsync(int id, string brand)
        {
            return ExecuteSafeAsync(()
                => _catalogBrandRepository.UpdateAsync(id, brand));
        }
    }
}
