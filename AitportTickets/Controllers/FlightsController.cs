﻿using AitportTickets.Data;
using AitportTickets.Models;
using AitportTickets.Models.ModelsVM;
using AitportTickets.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AitportTickets.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IFlights _flightsService;
        public FlightsController(IFlights flightsService)
        {
            _flightsService = flightsService;
        }
        // GET: FlightsController
        [HttpGet]
        public ActionResult Index()
        {
            FlightsVM flightsVM = new FlightsVM();

            flightsVM.FlightsByFilter = _flightsService.GetAllFlightsAsync().Result;
            flightsVM.AllFlights = _flightsService.GetAllFlightsAsync().Result;

            return PartialView(flightsVM);
        }

        #region Search flights
        //Search flight by number
        public ActionResult GetFlightByNumber()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetFlightByNumber(string number, DateTime date)
        {
            var model = _flightsService.GetFlightsByNumberAsync(number, date).Result;
            return View("Index", model);
        }

        //Search flight by city of departure
        public ActionResult GetFlightsByCity()
        {
            var city = _flightsService.GetCitiesDep();
            return View(city);
            
            //var model = _flightsService.GetAllFlightsAsync().Result;
            
            //return View(model);
        }
        [HttpPost]
        public ActionResult GetFlightsByCity(string city)
        {
            var model = _flightsService.GetFlightsByCityOfDepartureAsync(city).Result;
            return View("Index", model);
        }

        ////Search flight by city of departure and arrival
        //public ActionResult GetFlightsByCityDA()
        //{
        //    FlightsVM flightsVM = new FlightsVM();

        //    flightsVM.FlightsByFilter = _flightsService.GetAllFlightsAsync().Result;
        //    flightsVM.AllFlights = _flightsService.GetAllFlightsAsync().Result;

        //    return PartialView(flightsVM);
        //}
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult _GetFlightsByCityDA(string city, string city1)
        {
            FlightsVM flightsVM = new FlightsVM();

            flightsVM.FlightsByFilter = _flightsService.GetFlightByCityOfDepadtureAndArrivalAsync(city, city1).Result;
            flightsVM.AllFlights = _flightsService.GetAllFlightsAsync().Result;

            return PartialView(flightsVM);
        }

        //[HttpPost]
        //public JsonResult _GetFlightsByCityDA(string city, string city1)
        //{
        //    FlightsVM flightsVM = new FlightsVM();

        //    flightsVM.FlightsByFilter = _flightsService.GetFlightByCityOfDepadtureAndArrivalAsync(city, city1).Result;
        //    flightsVM.AllFlights = _flightsService.GetAllFlightsAsync().Result;

        //    return Json(flightsVM);
        //}


        public ActionResult GetFlightsByDate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetFlightsByDate(DateTime date)
        {
            var model = _flightsService.GetFlightsByDateOfDepartureAsync(date).Result;
            return View("Index", model);
        }

        #endregion

        #region Create Update Delete
        // GET: FlightsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlightsController/Create
        [HttpPost]
        public ActionResult Create(Flight flight)
        {
            try
            {
                _flightsService.Create(flight);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightsController/Edit/5
        public ActionResult Update(int id)
        {
            var flight = _flightsService.GetFlightsById(id).Result;
            return View(flight);
        }

        // POST: FlightsController/Edit/5
        [HttpPost]
        //[Authorize(Roles = "Admin" )]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Flight flight)
        {
            try
            {
                _flightsService.Update(flight);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightsController/Delete/5
        public ActionResult Delete(int id)
        {
            var flight = _flightsService.GetFlightsById(id).Result;
            return View(flight);
        }

        // POST: FlightsController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _flightsService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Index");
            }
        }
#endregion












        //// GET: FlightsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}





        
    }
}