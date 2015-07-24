
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
    }
}


