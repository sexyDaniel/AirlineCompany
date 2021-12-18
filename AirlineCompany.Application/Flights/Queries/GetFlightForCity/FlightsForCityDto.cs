using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetFlightForCity
{
    public class FlightsForCityDto
    {
        public int Id { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivedCity { get; set; }
    }
}
