using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jfe_application.Startup))]
namespace jfe_application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
