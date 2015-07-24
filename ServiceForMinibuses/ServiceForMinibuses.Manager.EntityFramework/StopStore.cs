

using System.Collections.Generic;
using System.Linq;
using Models;

namespace ServiceForMinibuses.Manager.EntityFramework
{
    public class StopStore: IStopStore
    {
          private readonly IDatabaseContext _databaseContext;
          public StopStore(IDatabaseContext databaseContext)
        {
             _databaseContext = databaseContext;
        }
        public Stop GetStopById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void AddStop(Stop stop)
        {
            _databaseContext.Stops.Add(stop);
            _databaseContext.Save();
        }

        public List<Route> GetStopsByRoutId(int routeId)
        {
            throw new System.NotImplementedException();
        }
    }
}
