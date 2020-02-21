using ProjectX.Persistence;

namespace ProjectX.Services.ShardServices
{
    public class CategoryService
    {
        private readonly ShardDbContext _context;
        public CategoryService(ServiceFactory serviceFactory)
        {
            _context = serviceFactory.Context;
        }

        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
