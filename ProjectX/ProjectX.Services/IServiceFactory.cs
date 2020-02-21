using ProjectX.Services.ShardServices;

namespace ProjectX.Services
{
    public interface IServiceFactory
    {
        CategoryService GetCategoryService();
    }
}
