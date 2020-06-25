using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectX.Services.DataTransferObjectViewModels.Categories;
using ProjectX.Services.DataTransferObjectViewModels.CategoryGroups;

namespace ProjectX.Models.ViewModels.CategoryGroups
{
    public class CategoryGroupViewModel
    {
        public int CategoryGroupId { get; set; }
        public string CategoryGroupName { get; set; }

        public class AutoMappings : AutoMapper.Profile
        {
            public AutoMappings()
            {
                CreateMap<CategoryGroupDtoViewModel, CategoryGroupViewModel>();
            }
        }
    }
}