using Ninject.Modules;
using Ninject.Web.Common;
using ProjectX.Caching;
using ProjectX.Caching.Contracts;

namespace ProjectX.Helpers
{
    public class CacheProviderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRedisCacheProvider>().To<RedisCacheProvider>().InRequestScope();
        }
    }
}