
using Models;
using System.Collections.Generic;

namespace ServiceForMinibuses.Web.Models
{
    public class RouteListViewModel
    {
        public List<CreateRouteViewModel> Routes { get; set;}

        public List<CreateStopViewModel> AllStops { get; set; }
    }
}