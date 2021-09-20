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
                Line = new Line
                {
                    Departure = AIRPORT.DTW,
                    Arrived = AIRPORT.JFK
                },
                Date = DateTime.Now.AddDays(5),
                Plane = plane,
                PriceSecondClass = 300
            });

            i++;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Line = new Line
                {
                    Departure = AIRPORT.JFK,
                    Arrived = AIRPORT.DTW
                },
                Date = DateTime.Now.AddDays(5),
                Plane = plane1,
                PriceSecondClass = 300,

            });

            i++;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Line = new Line
                {
                    Departure = AIRPORT.CDG,
                    Arrived = AIRPORT.DTW
                },
                Date = DateTime.Now.AddDays(5),
                Plane = plane2,
                PriceSecondClass = 700,
            });

            i++;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Line = new Line
                {
                    Departure = AIRPORT.DTW,
                    Arrived = AIRPORT.CDG
                },
                Date = DateTime.Now.AddDays(5),
                Plane = plane3,
                PriceSecondClass = 700,
            });

            i++;

            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Line = new Line
                {
                    Departure = AIRPORT.JFK,
                    Arrived = AIRPORT.CDG
                },
                Date = DateTime.Now.AddDays(5),
                Plane = plane4,
                PriceSecondClass = 1000,
            });

            i++;
            CACHE.Trips.Add(new Trip()
            {
                Id = i,
                Line = new Line
                {
                    Departure = AIRPORT.CDG,
                    Arrived = AIRPORT.JFK
                },
                Date = DateTime.Now.AddDays(5),
                Plane = plane5,
                PriceSecondClass = 1000,
            });
        }

        public void AddCustomerInPlane(Customer customer, Trip trip)
        {
            trip.Plane.Customers.Add(customer);
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
    }
}