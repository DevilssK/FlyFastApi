using FlyFast.API.Models;
using FlyFast.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

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
        [Route("Line")]
        public List<Trip> GetListOfLine()
        {
            List<Trip> trips = new List<Trip>();

            trips = _repository.GetTravels();

            return trips;
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