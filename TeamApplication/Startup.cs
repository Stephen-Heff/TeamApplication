using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamApplication.Startup))]
namespace TeamApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
