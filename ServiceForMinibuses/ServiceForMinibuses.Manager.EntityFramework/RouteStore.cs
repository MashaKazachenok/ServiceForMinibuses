
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Models;

namespace ServiceForMinibuses.Manager.EntityFramework
{
   
    public class RouteStore : IRouteStore
    {
          private readonly IDatabaseContext _databaseContext;
        public RouteStore(IDatabaseContext databaseContext)
        {
             _databaseContext = databaseContext;
        }
        public Route GetRouteById(int id)
        {
            return _databaseContext.Routes.FirstOrDefault(x => x.Id == id);
        }

        public List<Route> GetRoutes()
        {
            return _databaseContext.Routes
                .Include("Stops")
                .ToList();
        }

        public void AddRoute(Route route)
        {
            _databaseContext.Routes.Add(route);
            _databaseContext.Save();
        }

        public void RemoveRoute(int routeId)
        {
            var route = _databaseContext.Routes.FirstOrDefault(x => x.Id == routeId);
            _databaseContext.Routes.Remove(route);
            _databaseContext.Save();
        }
    }
}


