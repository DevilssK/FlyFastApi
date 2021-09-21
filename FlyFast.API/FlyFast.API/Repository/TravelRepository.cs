﻿using FlyFast.API.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FlyFast.API.Repository
{
    public class TravelRepository : IDisposable
    {
        #region [Logger]
        private static ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
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
            plane1.NbrPlaceFirstClass = 0;

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
                    Departure = AIRPORT.DTW.ToString(),
                    Arrived = AIRPORT.JFK.ToString(),
                    Plane = plane,
                    Price = 300,
                    Date = DateTime.Now.AddDays(5)
                  },
                  new Line()
                  {
                         Id= 2,
                    Departure = AIRPORT.JFK.ToString(),
                    Arrived = AIRPORT.CDG.ToString(),
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
                    Departure = AIRPORT.JFK.ToString(),
                    Arrived = AIRPORT.DTW.ToString(),
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
                    Departure = AIRPORT.CDG.ToString(),
                    Arrived = AIRPORT.DTW.ToString(),
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
                    Departure = AIRPORT.DTW.ToString(),
                    Arrived = AIRPORT.CDG.ToString(),
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
                    Departure = AIRPORT.JFK.ToString(),
                    Arrived = AIRPORT.CDG.ToString(),
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
                    Departure = AIRPORT.CDG.ToString(),
                    Arrived = AIRPORT.JFK.ToString(),
                    Plane = plane5,
                    Price = 1000,
                       Date = DateTime.Now.AddDays(5)
                  }
                },
                Date = DateTime.Now.AddDays(5),
            });

            CACHE.Orders.Add(new Order()
            {
                price = 1000,
                customer = new Customer()
                {
                    Name = "toto"
                },
                date = new DateTime(),
                trip = CACHE.Trips[1]

            });

            CACHE.Orders.Add(new Order()
            {
                price = 1000,
                customer = new Customer()
                {
                    Name = "tutu"
                },
                date = new DateTime(),
                trip = CACHE.Trips[1]

            });

        }

        internal void CreateOrder(int tripId, Customer customer, TICKET_TYPE type)
        {
            List<Line> lines = CACHE.Trips.Where(x => x.Id == tripId).FirstOrDefault().Line;

            float price = 0;
            if (lines.Count > 1)
            {

                foreach (Line item in lines)
                {
                    switch (type)
                    {
                        case (TICKET_TYPE.SECOND_CLASS):
                            price += item.Price;
                            break;
                        case (TICKET_TYPE.FIRST_CLASS):
                            price += item.Price * 2;
                            break;
                    }

                }

                price = price * 0.85f;
            }
            else
            {
                price = lines.FirstOrDefault().Price;
            }


            CACHE.Orders.Add(new Order()
            {
                price = price,
                date = DateTime.Now,
                trip = CACHE.Trips.Where(x => x.Id == tripId).FirstOrDefault(),
                customer = customer
            });

        }

        public void AddCustomerInPlane(Customer customer, Trip trip)
        {
            List<Line> lines = CACHE.Trips.Where(x => x.Id == trip.Id).FirstOrDefault().Line;

            float price = 0;
            if (lines.Count > 1)
            {

                foreach (Line item in lines)
                {
                    switch (customer.TickerType)
                    {
                        case (TICKET_TYPE.SECOND_CLASS):
                            price += item.Price;
                            break;
                        case (TICKET_TYPE.FIRST_CLASS):
                            price += item.Price * 2;
                            break;
                    }

                }

                price = price * 0.85f;
            }
            else
            {
                price = lines.FirstOrDefault().Price;
            }


            //CACHE.Orders.Add(new Order()
            //{
            //    price = price,
            //    date = DateTime.Now,
            //    trip = CACHE.Trips.Where(x=> x.Id == tripId).FirstOrDefault(),
            //    customer = customer
            //});

        }

        //public void AddCustomerInPlane(Customer customer, Trip trip)
        //{
        //    // trip.Line.Customers.Add(customer);
        //}


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
                _logger.Error(ex);
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