using FlyFast.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Repository
{
    public  class TravelRepository : IDisposable
    {
        public void Dispose()
        {
            
        }

        public void LoadData()
        {
            var plane = new Plane();
            plane.Places = 300;

            var plane1 = new Plane();
            plane.Places = 300;

            var plane2 = new Plane();
            plane.Places = 700;

            var plane3 = new Plane();
            plane.Places = 700;

            var plane4 = new Plane();
            plane.Places = 1000;

            var plane5 = new Plane();
            plane.Places = 1000;

            int i = 1;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Departure = AIRPORT.DTW.ToString(),
                Arrived = AIRPORT.JFK.ToString(),
                Date = DateTime.Now.AddDays(5),
                Plane = plane
            });

            i++;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Departure = AIRPORT.JFK.ToString(),
                Arrived = AIRPORT.DTW.ToString(),
                Date = DateTime.Now.AddDays(5),
                Plane = plane1
            });

            i++;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Departure = AIRPORT.CDG.ToString(),
                Arrived = AIRPORT.DTW.ToString(),
                Date = DateTime.Now.AddDays(5),
                Plane = plane2
            });

            i++;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Departure = AIRPORT.DTW.ToString(),
                Arrived = AIRPORT.CDG.ToString(),
                Date = DateTime.Now.AddDays(5),
                Plane = plane3
            });

            i++;

            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Departure = AIRPORT.JFK.ToString(),
                Arrived = AIRPORT.CDG.ToString(),
                Date = DateTime.Now.AddDays(5),
                Plane = plane4
            });

            i++;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Departure = AIRPORT.CDG.ToString(),
                Arrived = AIRPORT.JFK.ToString(),
                Date = DateTime.Now.AddDays(5),
                Plane = plane5
            });
        }
        public  List<Trip> GetTravels()
        {
            List<Trip> trips = new List<Trip>();

            try
            {
                //TODO: Connection BDD.
                trips = CACHE.Trips;
            }
            catch (Exception ex)
            {
            }

            return trips;
        }
    }
}