using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentWebMarket.Web.Startup))]
namespace StudentWebMarket.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
