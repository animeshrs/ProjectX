using ProjectX.Filters;
using System.Web.Mvc;

namespace ProjectX
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AddCacheBustingTag());
        }
    }
}
