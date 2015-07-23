using System.ComponentModel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ServiceForMinibuses.Web.Controllers;



namespace ServiceForMinibuses.Web.Common.IoC
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
             container.Register(Castle.MicroKernel.Registration.Component
                .For<HomeController>()
                .ImplementedBy<HomeController>()
                .LifeStyle.Transient);


             container.Register(Castle.MicroKernel.Registration.Component
                 .For<AccountController>()
                 .ImplementedBy<AccountController>()
                 .LifeStyle.Transient);

             container.Register(Castle.MicroKernel.Registration.Component
                 .For<RouteController>()
                 .ImplementedBy<RouteController>()
                 .LifeStyle.Transient);
             
        }
          
    }
}