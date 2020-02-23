using Ninject;
using Ninject.Modules;
using StackExchange.Redis;
using System.Diagnostics;

namespace ProjectX.Cache
{
    public class ProjectXCacheModule : NinjectModule
    {
        public override void Load()
        {
            Debug.Assert(Kernel != null, "Kernel!= null");
            Kernel.Bind<RedisConnectionStore>().ToSelf().InSingletonScope();
            Kernel.Bind<IConnectionMultiplexer>().ToMethod(cxm =>
                cxm.Kernel.Get<RedisConnectionStore>().Connection);
        }
    }
}
