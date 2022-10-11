using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InsightCorp.Startup))]
namespace InsightCorp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
