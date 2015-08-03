using System.Collections.Generic;

namespace Models
{
    public class Route
    {
        public Route()
        {
            Stops = new List<Stop>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Stop> Stops { get; set; }
    }
}
