using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectX.Startup))]
namespace ProjectX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
