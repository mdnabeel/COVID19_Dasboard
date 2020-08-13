using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Covid19_Dashboard.Startup))]
namespace Covid19_Dashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
