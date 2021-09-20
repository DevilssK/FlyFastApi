using FlyFast.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyFast.API.Repository
{
    public class TravelRepository : IDisposable
    {
        public void Dispose()
        {

        }

        public void LoadData()
        {
            var plane = new Plane();
            plane.MaxPlaces = 300;

            var plane1 = new Plane();
            plane.MaxPlaces = 300;

            var plane2 = new Plane();
            plane.MaxPlaces = 700;

            var plane3 = new Plane();
            plane.MaxPlaces = 700;

            var plane4 = new Plane();
            plane.MaxPlaces = 1000;

            var plane5 = new Plane();
            plane.MaxPlaces = 1000;

            int i = 1;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Line = new List<Line>()
                {
                  new Line()
                  {
                    Departure = AIRPORT.DTW,
                    Arrived = AIRPORT.JFK,
                    Plane = plane,
                    Price = 300
                  }
                }
               ,
                Date = DateTime.Now.AddDays(5),
            });

            i++;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Line = new List<Line>()
                {
                  new Line()
                  {
                    Departure = AIRPORT.JFK,
                    Arrived = AIRPORT.DTW,
                    Plane = plane,
                    Price = 300
                  }
                },
                Date = DateTime.Now.AddDays(5),

            });

            i++;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Line = new List<Line>()
                {
                  new Line()
                  {
                    Departure = AIRPORT.CDG,
                    Arrived = AIRPORT.DTW,
                    Plane = plane,
                    Price = 700
                  }
                },
                Date = DateTime.Now.AddDays(5)
            });

            i++;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Line = new List<Line>()
                {
                  new Line()
                  {
                    Departure = AIRPORT.DTW,
                    Arrived = AIRPORT.CDG,
                    Plane = plane,
                    Price = 700
                  }
                },
                Date = DateTime.Now.AddDays(5),
            });

            i++;

            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Line = new List<Line>()
                {
                  new Line()
                  {
                    Departure = AIRPORT.JFK,
                    Arrived = AIRPORT.CDG,
                    Plane = plane,
                    Price = 1000
                  }
                },
                Date = DateTime.Now.AddDays(5),
            });

            i++;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Line = new List<Line>()
                {
                  new Line()
                  {
                    Departure = AIRPORT.CDG,
                    Arrived = AIRPORT.JFK,
                    Plane = plane,
                    Price = 1000
                  }
                },
                Date = DateTime.Now.AddDays(5),
            });
        }

        public void AddCustomerInPlane(Customer customer, Trip trip)
        {
            // trip.Line.Customers.Add(customer);
        }


        public List<Trip> GetTravels()
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

        //public int PlacesInvalibility(Trip trip)
        //{
        //    int places = trip.Plane.MaxPlaces - trip.Plane.Customers.Count;
        //    return places;

        //}

        //public int FirstClassInvalibility(TICKET_TYPE type, Trip trip)
        //{
        //    int firstclassCustomers = trip.Plane.Customers.Where(x => x.TICKET_TYPE == TICKET_TYPE.FIRST_CLASS).Count();
        //    int firstClassPlaces = Convert.ToInt32(trip.Plane.MaxPlaces * 0.10);

        //    return firstClassPlaces - firstclassCustomers;
        //}
    }
}