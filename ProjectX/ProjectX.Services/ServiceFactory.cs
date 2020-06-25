using ProjectX.Persistence;
using ProjectX.Services.ShardServices;
using System.ComponentModel.Design;

namespace ProjectX.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceFactory : IServiceFactory
    {
        private readonly ServiceContainer _serviceContainer;
        private ShardDbContext _shardDbContext;
        private MasterDbContext _masterDbContext;

        public ServiceFactory(ServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
        }

        public ShardDbContext Context => _shardDbContext ?? (_shardDbContext = new ShardDbContext());
        public MasterDbContext MasterContext => _masterDbContext ?? (_masterDbContext = new MasterDbContext());

        public CategoryService GetCategoryService()
        {
            var service = (CategoryService)_serviceContainer.GetService(typeof(CategoryService));
            if (service != null)
                return service;

            service = new CategoryService(this);

            _serviceContainer.AddService(typeof(CategoryService), service);
            return service;
        }

        public CategoryGroupService GetCategoryGroupService()
        {
            var service = (CategoryGroupService)_serviceContainer.GetService(typeof(CategoryGroupService));
            if (service != null)
                return service;

            service = new CategoryGroupService(this);
            _serviceContainer.AddService(typeof(CategoryService), service);

            return service;
        }
    }
}
