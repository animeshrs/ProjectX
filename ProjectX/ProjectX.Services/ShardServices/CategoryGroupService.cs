using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectX.Persistence;
using ProjectX.Services.DataTransferObjectViewModels.CategoryGroups;

namespace ProjectX.Services.ShardServices
{
    public class CategoryGroupService
    {

        private readonly ShardDbContext _context;

        public CategoryGroupService(ServiceFactory serviceFactory)
        {
            _context = serviceFactory.Context;
        }

        public async Task<List<CategoryGroupDtoViewModel>> GetAllCategoryGroups()
        {
            var categoryGroups = await _context.CategoryGroups.ToListAsync();
            var categoryGroupDtos = categoryGroups.Select(cg => new CategoryGroupDtoViewModel
            {
                CategoryId = cg.CategoryId,
                CategoryGroupId = cg.CategoryGroupId,
                CategoryGroupName = cg.CategoryGroupName
            }).ToList();

            return categoryGroupDtos;
        }

        public void AddCategoryGroup(CategoryGroup categoryGroup)
        {
            _context.CategoryGroups.Add(categoryGroup);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
