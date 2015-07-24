
using System.Collections.Generic;
using System.Linq;
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

        public List<Route> GetRoutes(int userId)
        {
            return _databaseContext.Routes
                .ToList();
        }

        public void AddRoute(string routeName, List<Stop> stops )
        {
            _databaseContext.Routes.Add(new Route()
            {
                Name = routeName,
                Stops = stops
            });
            _databaseContext.Save();
        }
    }
}


