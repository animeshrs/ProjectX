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

        public ServiceFactory(ServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
        }

        public ShardDbContext Context => _shardDbContext ?? (_shardDbContext = new ShardDbContext());

        public CategoryService GetCategoryService()
        {
            var service = (CategoryService)_serviceContainer.GetService(typeof(CategoryService));
            if (service != null)
                return service;

            service = new CategoryService();

            _serviceContainer.AddService(typeof(CategoryService), service);
            return service;
        }
    }
}
