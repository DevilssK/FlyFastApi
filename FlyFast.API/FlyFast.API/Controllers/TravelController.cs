using FlyFast.API.Models;
using FlyFast.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FlyFast.API.Controllers
{
    [Route("api/[controller]")]
    public class TravelController : ApiController
    {

        [HttpGet]
        [Route("Travels")]
        public List<Trip> GetListOfTravel()
        {
            List<Trip> trips = new List<Trip>();

            using (TravelRepository travelRepository = new TravelRepository ())
            {
                trips = travelRepository.GetTravels();
            }
            return trips;
        }

         
    }
}