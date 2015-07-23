using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using ServiceForMinibuses.Web.Common.IoC;

namespace ServiceForMinibuses.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IWindsorContainer Container;
        protected void Application_Start()
        {

            Container = new WindsorContainer()
                .Install(new ControllerInstaller())
                .Install(new PersistenceInstaller());


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
