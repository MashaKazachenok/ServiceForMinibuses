using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ServiceForMinibuses.Manager;
using ServiceForMinibuses.Manager.EntityFramework;


namespace ServiceForMinibuses.Web.Common.IoC
{
    public class PersistenceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<IDatabaseContext>()
                .ImplementedBy<DatabaseContext>()
                .DependsOn(Dependency.OnValue("nameOrConnectionString", "DefaultConnection"))
                .LifeStyle.PerWebRequest
            );

            container.Register(Component
               .For<IStopStore>()
               .ImplementedBy<StopStore>()
               .LifeStyle.Transient
           );

            container.Register(Component
               .For<IRouteStore>()
               .ImplementedBy<RouteStore>()
               .LifeStyle.Transient

           );

        }
    }
}