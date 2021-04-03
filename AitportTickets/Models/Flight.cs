using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AitportTickets.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DateTimeDeparture { get; set; }
        public DateTime DateTimeArrival { get; set; }
        public string CityDeparture { get; set; }
        public string CityArrival { get; set;}
        //public string TerminalDeparture { get; set; }
        //public string TerminalArrival { get; set; }
        public virtual List<Passenger> Passengers { get; set; }
    }
}
