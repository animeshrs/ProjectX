using ProjectX.Helpers;
using System;
using System.Web;
using System.Web.Mvc;

namespace ProjectX.Filters
{
    public class AddCacheBustingTag : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cookie = new HttpCookie("cache-buster-tag", CacheBuster.Tag())
            {
                Expires = DateTime.Now.AddMinutes(1),
                HttpOnly = true
            };

            filterContext.HttpContext.Response.Cookies.Add(cookie);
        }
    }
}