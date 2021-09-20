using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models
{
    public class Line
    {
        public int Id { get; set; }
        public AIRPORT Departure { get; set; }
        public AIRPORT Arrived { get; set; }
        public Plane Plane { get; set; }
        public float Price { get; set; }
    }
}