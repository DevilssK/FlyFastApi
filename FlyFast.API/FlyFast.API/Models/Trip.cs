using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public string Arrived { get; set; }
        public DateTime Date { get; set; }
        //public double Price { get; set; }
        public Plane Plane { get; set; }

    }
}