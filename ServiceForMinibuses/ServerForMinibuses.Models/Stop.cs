using System.Collections.Generic;

namespace Models
{
    public class Stop
    {
       public Stop()
       {
          Routes = new List<Route>();
       }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Route> Routes { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
    }
}
