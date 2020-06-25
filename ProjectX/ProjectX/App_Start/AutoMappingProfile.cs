using AutoMapper;
using ProjectX.Models.ViewModels.Categories;
using ProjectX.Models.ViewModels.CategoryGroups;
using ProjectX.Services.DataTransferObjectViewModels.Categories;
using ProjectX.Services.DataTransferObjectViewModels.CategoryGroups;

namespace ProjectX
{
    public class AutoMapppingProfile : Profile
    {
        public AutoMapppingProfile()
        {
            CreateMap<CategoryDtoViewModel, CategoryViewModel>();
            CreateMap<CategoryGroupDtoViewModel, CategoryGroupViewModel>();

        }
    }
}