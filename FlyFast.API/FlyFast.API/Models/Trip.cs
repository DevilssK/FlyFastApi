using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public AIRPORT Departure { get; set; }
        public AIRPORT Arrived { get; set; }
        public DateTime Date { get; set; }
        //public double Price { get; set; }
        public Plane Plane { get; set; }

    }
}