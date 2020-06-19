using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DirectorsManual.Web.Startup))]
namespace DirectorsManual.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
