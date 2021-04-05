using AitportTickets.Data;
using AitportTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AitportTickets.Services
{
    public class FlightsService : IFlights
    {
        private readonly ApplicationDbContext _applicatioDbContext;
        public FlightsService(ApplicationDbContext applicatioDbContext)
        {
            _applicatioDbContext = applicatioDbContext;
        }


        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            var testResult = await _applicatioDbContext.Flights.Select(i=>i).ToListAsync();
            return testResult;
        }

        #region Search

        public async Task<List<Flight>> GetFlightByCityOfDepadtureAndArrivalAsync(string cityD, string cityA)
        {
            IQueryable<Flight> testResult = _applicatioDbContext.Flights.Where(i => i.CityDeparture == cityD);
            return await testResult.Where(i => i.CityArrival == cityA).ToListAsync();
        }
        public async Task<List<Flight>> GetFlightsByCityOfDepartureAsync(string city)
        {
            var testResult = await _applicatioDbContext.Flights.Where(i => i.CityDeparture == city).ToListAsync();
            return testResult;
        }

        public async Task<List<Flight>> GetFlightsByDateOfDepartureAsync(DateTime date)
        {
            var testResult = await _applicatioDbContext.Flights.Where(i => i.DateTimeDeparture.Date == date.Date).ToListAsync();
            return testResult;
        }

        public async Task<List<Flight>> GetFlightsByNumberAsync(string number, DateTime date)
        {
            IQueryable<Flight> testResult = _applicatioDbContext.Flights.Where(i => i.FlightNumber == number);
            return await testResult.Where(i => i.DateTimeDeparture == date).ToListAsync();
        }

        public async Task<Flight> GetFlightsById(int id)
        {
            var testResult = await _applicatioDbContext.Flights.FirstOrDefaultAsync(i => i.Id == id);
            return testResult;
        }

        #endregion

        public List<string> GetCities()
        {
            List<string> cityDep = _applicatioDbContext.Flights.Select(x => x.CityDeparture).ToList();
            List<string> cityAr = _applicatioDbContext.Flights.Select(x => x.CityDeparture).ToList();
            foreach (var city in cityAr)
            {
                cityDep.Add(city);
            }
            List<string> cities = cityDep.Distinct<string>().ToList();
            return cities;
        }


        #region Create Update Delete
        public void Create(Flight obj)
        {
             _applicatioDbContext.Flights.Add(obj);
            _applicatioDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var flight = _applicatioDbContext.Flights.Find(id);
            _applicatioDbContext.Flights.Remove(flight);
            _applicatioDbContext.SaveChanges();
        }
        public void Update(Flight obj)
        {
            _applicatioDbContext.Flights.Update(obj);
            _applicatioDbContext.SaveChanges();
        }
        #endregion
    }
}
