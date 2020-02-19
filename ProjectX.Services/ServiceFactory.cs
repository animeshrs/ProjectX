using ProjectX.Services.Services;

namespace ProjectX.Services
{
    public class ServiceFactory : IServiceFactory
    {
        public CategoryService GetCategoryService()
        {
            return new CategoryService();
        }
    }
}
