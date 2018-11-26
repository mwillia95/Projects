using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AU_ACM_Site.Startup))]
namespace AU_ACM_Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
