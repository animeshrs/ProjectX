using ProjectX.Persistence;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ProjectX.Services.DataTransferObjectViewModels.Categories;

namespace ProjectX.Services.ShardServices
{
    public class CategoryService
    {
        private readonly ShardDbContext _context;
        public CategoryService(ServiceFactory serviceFactory)
        {
            _context = serviceFactory.Context;
        }

        public async Task<List<CategoryDtoViewModel>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            var categoryDtos = categories.Select(c => new CategoryDtoViewModel
            {
                CategoryName = c.CategoryName,
                CategoryId = c.CategoryId
            }).ToList();

            return categoryDtos;
        }
    }
}
