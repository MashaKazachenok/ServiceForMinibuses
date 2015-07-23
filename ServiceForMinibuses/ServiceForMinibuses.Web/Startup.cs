using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceForMinibuses.Web.Startup))]
namespace ServiceForMinibuses.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
