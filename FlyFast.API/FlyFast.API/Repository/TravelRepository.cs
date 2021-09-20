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
                    Plane = plane
                  }
                }
               ,
                Date = DateTime.Now.AddDays(5),
                PriceSecondClass = 300
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
                    Plane = plane
                  }
                },
                Date = DateTime.Now.AddDays(5),
                PriceSecondClass = 300,

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
                    Plane = plane
                  }
                },
                Date = DateTime.Now.AddDays(5),
                PriceSecondClass = 700,
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
                    Plane = plane
                  }
                },
                Date = DateTime.Now.AddDays(5),
                PriceSecondClass = 700,
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
                    Plane = plane
                  }
                },
                Date = DateTime.Now.AddDays(5),
                PriceSecondClass = 1000,
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
                    Plane = plane
                  }
                },
                Date = DateTime.Now.AddDays(5),
                PriceSecondClass = 1000,
            });
        }

        public void AddCustomerInPlane(Customer customer, Trip trip)
        {
            foreach(Line item in trip.Line)
            {
                item.Plane.Customers.Add(customer);
            }

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

        public int PlacesInvalibility(Trip trip)
        {
            //int places = trip.Plane.MaxPlaces - trip.Plane.Customers.Count;
            return 0;

        }

        public int FirstClassInvalibility(TICKET_TYPE type, Trip trip)
        {
            //int firstclassCustomers = trip.Plane.Customers.Where(x => x.TICKET_TYPE == TICKET_TYPE.FIRST_CLASS).Count();
           // int firstClassPlaces = Convert.ToInt32(trip.Plane.MaxPlaces * 0.10);

            return 0;
        }
    }
}