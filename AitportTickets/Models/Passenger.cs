using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTickets.Models
{
    public class Sex
    {
        public int SexId { get; set; }
        public string SexName { get; set; }
    }
    public class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passport { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public int SexId { get; set; }
        public virtual Sex Sex { get; set; }
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
