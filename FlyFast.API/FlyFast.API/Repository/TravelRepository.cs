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
            plane.NbrPlaceFirstClass = 0;


            var plane6 = new Plane();
            plane6.MaxPlaces = 1000;
            plane6.NbrPlaceFirstClass = Convert.ToInt32(plane6.MaxPlaces * 0.1F);

            var plane1 = new Plane();
            plane1.MaxPlaces = 300;
            plane1.NbrPlaceFirstClass = Convert.ToInt32(plane1.MaxPlaces * 0.1F);

          var plane2 = new Plane();
            plane2.MaxPlaces = 700;
            plane2.NbrPlaceFirstClass = Convert.ToInt32(plane2.MaxPlaces * 0.1F);

            var plane3 = new Plane();
            plane3.MaxPlaces = 700;
            plane3.NbrPlaceFirstClass = Convert.ToInt32(plane3.MaxPlaces * 0.1F);

            var plane4 = new Plane();
            plane4.MaxPlaces = 1000;
            plane4.NbrPlaceFirstClass = Convert.ToInt32(plane4.MaxPlaces * 0.1F);

            var plane5 = new Plane();
            plane5.MaxPlaces = 1000;
            plane5.NbrPlaceFirstClass = Convert.ToInt32(plane5.MaxPlaces * 0.1F);

            int i = 1;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Line = new List<Line>()
                {
                  new Line()
                  {
                      Id= 1,
                    Departure = AIRPORT.DTW,
                    Arrived = AIRPORT.JFK,
                    Plane = plane,
                    Price = 300,
                    Date = DateTime.Now.AddDays(5)
                  },
                  new Line()
                  {
                         Id= 2,
                    Departure = AIRPORT.JFK,
                    Arrived = AIRPORT.CDG,
                    Plane = plane6,
                    Price = 300,
                     Date = DateTime.Now.AddDays(6)
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
                         Id= 3,
                    Departure = AIRPORT.JFK,
                    Arrived = AIRPORT.DTW,
                    Plane = plane1,
                    Price = 300,
                       Date = DateTime.Now.AddDays(5)
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
                         Id= 4,
                    Departure = AIRPORT.CDG,
                    Arrived = AIRPORT.DTW,
                    Plane = plane2,
                    Price = 700,
                       Date = DateTime.Now.AddDays(5)
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
                         Id= 5,
                    Departure = AIRPORT.DTW,
                    Arrived = AIRPORT.CDG,
                    Plane = plane3,
                    Price = 700,
                       Date = DateTime.Now.AddDays(5)
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
                         Id= 6,
                    Departure = AIRPORT.JFK,
                    Arrived = AIRPORT.CDG,
                    Plane = plane4,
                    Price = 1000,
                       Date = DateTime.Now.AddDays(5)
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
                         Id= 7,
                    Departure = AIRPORT.CDG,
                    Arrived = AIRPORT.JFK,
                    Plane = plane5,
                    Price = 1000,
                       Date = DateTime.Now.AddDays(5)
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