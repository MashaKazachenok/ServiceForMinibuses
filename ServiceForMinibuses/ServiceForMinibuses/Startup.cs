using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceForMinibuses.Startup))]
namespace ServiceForMinibuses
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
