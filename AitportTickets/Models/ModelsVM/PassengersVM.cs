using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirportTickets.Models
{
    public class PassengersVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passport { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string FlightNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime FlightDate { get; set; }
    }
}
