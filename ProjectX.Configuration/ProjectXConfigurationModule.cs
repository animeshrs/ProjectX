using Ninject.Modules;

namespace ProjectX.Configuration
{
    public class ProjectXConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProjectXConfigurationManager>().To<ProjectXConfigurationManager>();
        }
    }
}
