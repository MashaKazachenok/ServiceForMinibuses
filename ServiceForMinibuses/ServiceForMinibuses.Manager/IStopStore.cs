

using System.Collections.Generic;
using Models;

namespace ServiceForMinibuses.Manager
{
    public interface IStopStore
    {
        Stop GetStopById(int id);
        void AddStop(Stop stop);
        List<Route> GetStopsByRoutId(int routeId);
        List<Stop> GetStops();
    }
}
