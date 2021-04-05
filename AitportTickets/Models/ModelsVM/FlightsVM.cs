using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTickets.Models.ModelsVM
{
    public class FlightsVM
    {
        public List<Flight> FlightsByFilter { get; set; }

        public List<string> Cities { get; set; }
    }
}
