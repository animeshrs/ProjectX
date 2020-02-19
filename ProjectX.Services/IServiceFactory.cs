using ProjectX.Services.Services;

namespace ProjectX.Services
{
    public interface IServiceFactory
    {
        CategoryService GetCategoryService();
    }
}
