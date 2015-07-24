using System.Collections.Generic;
using Models;

namespace ServiceForMinibuses.Manager
{
    public interface IRouteStore
    {
        Route GetRouteById(int id);
        List<Route> GetRoutes();
        void AddRoute(Route route);
    }
}
