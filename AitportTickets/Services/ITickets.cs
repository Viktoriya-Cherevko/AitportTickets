using AirportTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTickets.Services
{
    public interface ITickets
    {
        public Task<List<Ticket>> GetAllTicketsAsync();
        public Task<Ticket> GetTicketAsync();
    }
}
