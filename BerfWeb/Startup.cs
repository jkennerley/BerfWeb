using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BerfWeb.Startup))]
namespace BerfWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
