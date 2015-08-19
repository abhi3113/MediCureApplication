using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthPlanPortal.Startup))]
namespace HealthPlanPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
