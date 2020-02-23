using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectX.Caching
{
    public static class CacheKeys
    {
        public static string NumDaysInWeek => "NumDaysInWeek";

        public static string CategoryName(int categoryId) => $"Category with Id {categoryId}";
    }
}