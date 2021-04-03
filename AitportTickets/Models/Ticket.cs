using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AitportTickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime DateOfBuy { get; set; }
        public int FlightId { get; set; }
        //public virtual Flight Flight { get; set; }
        public int PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }
        public decimal Price { get; set; }

    }
}
