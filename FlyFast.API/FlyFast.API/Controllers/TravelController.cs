﻿using FlyFast.API.Models;
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
        public List<Trip> GetListOfTravel()
        {
            List<Trip> trips = new List<Trip>();

            return trips;
        }

         
    }
}