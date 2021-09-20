using FlyFast.API.Models;
using FlyFast.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FlyFast.API.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TravelController : ApiController
    {

        TravelRepository _repository = new TravelRepository();

        [HttpGet]
        [Route("Travels")]
        public List<Trip> GetListOfTravel()
        {
            List<Trip> trips = new List<Trip>();

            trips = _repository.GetTravels();

            return trips;
        }

        [HttpGet]
        [Route("Lines")]
        public List<Line> GetListOfLines()
        {
            List<Line> Lines = new List<Line>();
            foreach (var item in _repository.GetTravels())
            {
                foreach (var line in item.Line)
                {
                    Line oneLine = new Line();
                    oneLine.Id = line.Id;
                    oneLine.Price = line.Price;
                    oneLine.Arrived = line.Arrived;
                    oneLine.Departure = line.Departure;
                    oneLine.Date = line.Date;
                    Lines.Add(oneLine);
                }
            }
          

            return Lines;
        }


        [HttpPost]
        [Route("Book")]
        public bool PostReservation(string customerName, int tripId)
        {
            Customer customer = new Customer();
            customer.Name = customerName;
            Trip trip = CACHE.Trips.Where(x => x.Id == tripId).FirstOrDefault();
            _repository.AddCustomerInPlane(customer, trip);
            return true;
        }
    }
}