using Ninject.Modules;
using Ninject.Web.Common;
using ProjectX.Services;

namespace ProjectX
{
    public class WebModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ServiceFactory, IServiceFactory>().To<ServiceFactory>().InRequestScope();
        }
    }
}