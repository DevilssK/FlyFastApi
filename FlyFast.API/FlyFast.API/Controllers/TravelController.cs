using FlyFast.API.Models;
using FlyFast.API.Models.ViewModels;
using FlyFast.API.Repository;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FlyFast.API.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TravelController : ApiController
    {
        #region [Logger]
        private static ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        TravelRepository _repository = new TravelRepository();
        DeviseRepository _DeviseRepository = new DeviseRepository();

        [HttpGet]
        [Route("Rate")]
        public async Task<Devise> GetRate(string Devise)
        {
            Devise devise = new Devise();

            devise = (await CACHE.Devises()).Where(x => x.Currency == Devise).FirstOrDefault();

            return devise;

        }

        [HttpGet]
        [Route("Travels")]
        public List<Trip> GetListOfTravel()
        {
            List<Trip> trips = new List<Trip>();

            trips = _repository.GetTravels();

            return trips;
        }

        [HttpGet]
        [Route("Travels")]
        public List<Trip> GetListOfTravel([FromUri] string date)
        {
            List<Trip> trips = new List<Trip>();

            trips = _repository.GetTravels();
            var sortedTrip = trips.Where(x => x.Date == Convert.ToDateTime(date)).ToList();  
            return sortedTrip;
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

        [HttpGet]
        [Route("Lines")]
        public List<Line> GetListOfLines([FromUri] string date)
        {
            _logger.Debug("================================================================");
            _logger.Debug("Request [Route('Lines')] ");
            _logger.Debug($"Param  : {date}");
            _logger.Debug("================================================================");

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
            
            List<Line> SortedLines = Lines.Where(x=>x.Date == Convert.ToDateTime(date)).ToList();
            return SortedLines;
        }
            

        [HttpGet]
        [Route("Orders")]
        public List<Order> GetOrder(string Username)
        {
            List<Order> orders = null;

            _logger.Debug("================================================================");
            _logger.Debug("Request [Route('Order')] ");
            _logger.Debug($"Param  : {Username}");
            _logger.Debug("================================================================");

            if (CACHE.Orders.Where(w => w.customer.Name == Username).Count() > 0)
            {
                orders = new List<Order>();
                orders = CACHE.Orders.Where(w => w.customer.Name == Username).ToList();
            }

            return orders;
        }

        [HttpPost]
        [Route("Book")]
        public bool PostReservation(ReservationViewModel reservation)
        {
            _logger.Debug("================================================================");
            _logger.Debug("Request [Route('Book')] ");
            _logger.Debug($"ViewModel en param  : {Newtonsoft.Json.JsonConvert.SerializeObject(reservation)}");
            _logger.Debug("================================================================");
            Customer customer = new Customer();
            customer.Name = reservation.customerName;
            Trip trip = CACHE.Trips.Where(x => x.Id == reservation.tripId).FirstOrDefault();
            _repository.CreateOrder(reservation.tripId, customer, reservation.ticketTypes);
            return true;
        }
    }
}