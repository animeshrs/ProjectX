using Ninject.Modules;
using Ninject.Web.Common;

namespace ProjectX.Services
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ServiceFactory, IServiceFactory>().To<ServiceFactory>().InRequestScope();
        }
    }
}
