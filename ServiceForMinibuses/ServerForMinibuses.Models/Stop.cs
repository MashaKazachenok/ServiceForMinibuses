﻿using System.Collections.Generic;

namespace Models
{
    public class Stop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Route> Routes { get; set; }
    }
}
