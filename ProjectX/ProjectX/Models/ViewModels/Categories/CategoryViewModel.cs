using ProjectX.Persistence;

namespace ProjectX.Models.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public class AutoMappings : AutoMapper.Profile
        {
            public AutoMappings()
            {
                CreateMap<Category, CategoryViewModel>();
            }
        }
    }
}