using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetFlights
{
    public class FlightDto
    {
        public int Id { get; set; }
        public string ArriverCity { get; set; }
        public string DepartureCity { get; set; }
        public DateTime ArriverDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string CurrentPlane { get; set; }
        public string CurrentCaptain { get; set; } = "-";
    }
}
