﻿

using System.Collections.Generic;

namespace Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Stop> Stops { get; set; }
    }
}
