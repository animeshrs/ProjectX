using ProjectX.Persistence;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ProjectX.Services.ShardServices
{
    public class CategoryService
    {
        private readonly ShardDbContext _context;
        public CategoryService(ServiceFactory serviceFactory)
        {
            _context = serviceFactory.Context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
    }
}
