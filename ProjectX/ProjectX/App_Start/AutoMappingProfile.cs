using AutoMapper;
using ProjectX.Models.ViewModels.Categories;
using ProjectX.Persistence;

namespace ProjectX
{
    public class AutoMapppingProfile : Profile
    {
        public AutoMapppingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
        }
    }
}