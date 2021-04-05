using AirportTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTickets.Services
{
    public interface IPassengers
    {
        public Task<List<Passenger>> GetAllPassengersAsync();
        public Task<List<PassengersVM>> GetAllPassengersVMAsync();
        public Task<Passenger> GetPassengerByIdAsync(int id);

        public Task<List<PassengersVM>> GetPassengersByFlightNumberAsync(string number, DateTime date);

        public void Create(Passenger obj);
        public void Update(Passenger obj);
        public void Delete(int id);

    }
}
