
using System.Collections.Generic;
using Models;

namespace ServiceForMinibuses.Web.Models
{
    public class CreateRouteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Stop> Stops { get; set; }
    }
}