using AirportTickets.Data;
using AirportTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTickets.Services
{
    public class PassengersService : IPassengers
    {
        private readonly ApplicationDbContext _applicatioDbContext;
        public PassengersService(ApplicationDbContext applicatioDbContext)
        {
            _applicatioDbContext = applicatioDbContext;
        }


        // Get all passengers Model:Passenger
        public async Task<List<Passenger>> GetAllPassengersAsync()
        {
            var ListOfPassengers = await _applicatioDbContext.Passengers.Select(i => i).ToListAsync();

            return ListOfPassengers;
        }

        // Get all passengers Model:PassengersVM
        public async Task<List<PassengersVM>> GetAllPassengersVMAsync()
        {
            var ListOfPassengers = await _applicatioDbContext.Passengers.Select(i => i).ToListAsync();
            List<PassengersVM> passengersVMList = new List<PassengersVM>();
            foreach (var pas in ListOfPassengers)
            {
                passengersVMList.Add(new PassengersVM()
                {
                    Id = pas.Id,
                    FirstName = pas.FirstName,
                    LastName = pas.LastName,
                    Passport = pas.Passport,
                    DateOfBirth = pas.DateOfBirth,
                    Sex = _applicatioDbContext.Sexes.FirstOrDefault(i => i.SexId == pas.SexId).SexName.ToString(),
                    FlightNumber = _applicatioDbContext.Flights.FirstOrDefault(i => i.Id == pas.FlightId).FlightNumber.ToString(),//flight.FlightNumber,
                    FlightDate = _applicatioDbContext.Flights.FirstOrDefault(i => i.Id == pas.FlightId).DateTimeDeparture//flight.DateTimeDeparture

                });
            }
            return passengersVMList;
        }



        public async Task<Passenger> GetPassengerByIdAsync(int id)
        {
            var testResult = await _applicatioDbContext.Passengers.FirstOrDefaultAsync(i => i.Id == id);
            return testResult;
        }

        // Get passengers by flight number Model:PassengersVM
        public async Task<List<PassengersVM>> GetPassengersByFlightNumberAsync(string number, DateTime date)
        {
            var flights = _applicatioDbContext.Flights.Where(i => i.FlightNumber == number);
            var flight = flights.FirstOrDefault(i => i.DateTimeDeparture.Date == date.Date);
            var passengers = await _applicatioDbContext.Passengers.Where(i => i.FlightId == flight.Id).ToListAsync();
            List<PassengersVM> passengersVMList = new List<PassengersVM>();
            foreach (var pas in passengers)
            {
                passengersVMList.Add(new PassengersVM()
                {

                    Id = pas.Id,
                    FirstName = pas.FirstName,
                    LastName = pas.LastName,
                    Passport = pas.Passport,
                    DateOfBirth = pas.DateOfBirth,
                    Sex = _applicatioDbContext.Sexes.FirstOrDefault(i=>i.SexId == pas.SexId).SexName.ToString(),
                    FlightNumber = flight.FlightNumber,
                    FlightDate = flight.DateTimeDeparture

                });
            }
            return passengersVMList;
        }
           


        public void Update(Passenger obj)
        {
            _applicatioDbContext.Passengers.Update(obj);
            _applicatioDbContext.SaveChanges();
        }

        public void Create(Passenger obj)
        {
            _applicatioDbContext.Passengers.Add(obj);
            _applicatioDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var passenger = _applicatioDbContext.Passengers.Find(id);
            _applicatioDbContext.Passengers.Remove(passenger);
            _applicatioDbContext.SaveChanges();
        }
    }
}
