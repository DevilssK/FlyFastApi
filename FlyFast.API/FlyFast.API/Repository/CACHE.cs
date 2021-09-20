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
            // Fake Data

           
        }
        public static List<Trip> Trips = new List<Trip> ();

        internal static void LoadData()
        {
            using (TravelRepository travelRepository =  new TravelRepository ())
            {
                travelRepository.LoadData();
            }
        }
    }
}