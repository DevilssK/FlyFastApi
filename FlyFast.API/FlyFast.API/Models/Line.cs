using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models
{
    public class Line
    {
        public AIRPORT Departure { get; set; }
        public AIRPORT Arrived { get; set; }
        public Plane Plane { get; set; }
    }
}