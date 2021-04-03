using AitportTickets.Data;
using AitportTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AitportTickets.Services
{
    public class TicketsService : ITickets
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TicketsService (ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            var ListOfTickets = await _applicationDbContext.Tickets.Select(i => i).ToListAsync();
            return ListOfTickets;
            //throw new NotImplementedException();
        }

        public Task<Ticket> GetTicketAsync()
        {
            throw new NotImplementedException();
        }
    }
}
