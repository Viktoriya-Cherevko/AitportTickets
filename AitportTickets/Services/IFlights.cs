using AitportTickets.Data;
using AitportTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AitportTickets.Services
{
    public interface IFlights
    {
        public Task<List<Flight>> GetAllFlightsAsync();
        public Task<List<Flight>> GetFlightsByNumberAsync(string number, DateTime date);
        public Task<List<Flight>> GetFlightsByCityOfDepartureAsync(string city);
        public Task<List<Flight>> GetFlightsByDateOfDepartureAsync(DateTime date);
        public Task<Flight> GetFlightsById(int id);

        public Task<List<Flight>> GetFlightByCityOfDepadtureAndArrivalAsync(string cityD, string cityA);

        public List<string> GetCitiesDep();


        public void Create(Flight obj);
        public void Update (Flight obj);
        public void Delete(int id);
    }
}
