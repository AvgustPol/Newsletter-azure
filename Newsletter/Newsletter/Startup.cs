using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Newsletter.Startup))]
namespace Newsletter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
