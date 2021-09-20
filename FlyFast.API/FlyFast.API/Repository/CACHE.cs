using FlyFast.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Repository
{
    public sealed class CACHE
    {
        public CACHE()
        {
            Trips = new List<Trip>();

            // Fake Data
        }
        public static List<Trip> Trips = null;
    }
}