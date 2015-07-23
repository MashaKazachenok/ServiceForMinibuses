using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ServiceForMinibuses.Web
{
    public class CastleWindsorControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)MvcApplication.Container.Resolve(controllerType);
        }
    }
}


