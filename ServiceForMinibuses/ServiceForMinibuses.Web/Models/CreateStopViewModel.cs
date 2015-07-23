using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceForMinibuses.Web.Models
{
    public class CreateStopViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        
    }
}