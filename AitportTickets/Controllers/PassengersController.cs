using AirportTickets.Models;
using AirportTickets.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTickets.Controllers
{
    public class PassengersController : Controller
    {
        private readonly IPassengers _passengerService;

        public PassengersController (IPassengers passengerService)
        {
            _passengerService = passengerService;
        }


        // GET: ALL Passengers (VM)
        public ActionResult Index()
        {
            var model = _passengerService.GetAllPassengersVMAsync().Result;
            return View(model);
        }


        // Get Passengers By Fligh tNumber (VM)
        public ActionResult GetPassengersByFlightNumber()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetPassengersByFlightNumber(string number, DateTime date)
        {
            var model = _passengerService.GetPassengersByFlightNumberAsync(number, date).Result;
            return View("Index", model);
        }





        // GET: Create
        public ActionResult Create(int id)
        {
            Passenger passenger = new Passenger { FlightId = id };
            return View(passenger);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Passenger passenger)
        {
            try
            {
                _passengerService.Create(passenger);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       

        // GET: PassengersController/Edit/5
        public ActionResult Update(int id)
        {
            var passenger = _passengerService.GetPassengerByIdAsync(id).Result;
            return View(passenger);
        }

        // POST: PassengersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Passenger passenger)
        {
            try
            {
                _passengerService.Update(passenger);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PassengersController/Delete/5
        public ActionResult Delete(int id)
        {
            var passenger = _passengerService.GetPassengerByIdAsync(id).Result;
            return View(passenger);
        }

        // POST: PassengersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _passengerService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
