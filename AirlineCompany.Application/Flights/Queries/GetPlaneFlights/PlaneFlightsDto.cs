using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetPlaneFlights
{
    public class PlaneFlightsDto
    {
        public int Id { get; set; }
        public string DepartyreCity { get; set; }
        public string ArrivedCity { get; set; }
    }
}
