

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
            return _databaseContext.Stops.FirstOrDefault(x => x.Id == id);
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

        public List<Stop> GetStops()
        {
            return _databaseContext.Stops
                .ToList();
        }

        public Stop GetStopByName(string stopName)
        {
            return _databaseContext.Stops.FirstOrDefault(x => x.Name == stopName);
        }

        public void UpdateStop(Stop findStop)
        {
            Stop stop = GetStopById(findStop.Id);
            stop.Name = findStop.Name;

            if (stop != null)
            {
                stop.Routes = findStop.Routes;
            }
            _databaseContext.Save();
        }
    }
}
