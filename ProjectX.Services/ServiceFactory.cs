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
        public ServiceFactory(ServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
        }

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
