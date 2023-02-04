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

        public Task<int?> Add(string brand)
        {
            return ExecuteSafeAsync(()
                => _catalogBrandRepository.Add(brand));
        }

        public Task<EntityModifyState> Remove(int id)
        {
            return ExecuteSafeAsync(()
                => _catalogBrandRepository.Remove(id));
        }

        public Task<EntityModifyState> Update(int id, string brand)
        {
            return ExecuteSafeAsync(()
                => _catalogBrandRepository.Update(id, brand));
        }
    }
}
