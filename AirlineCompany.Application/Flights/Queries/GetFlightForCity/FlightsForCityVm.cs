using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetFlightForCity
{
    public class FlightsForCityVm
    {
        public List<FlightsForCityDto> DepartyreFlights { get; set; }
        public List<FlightsForCityDto> ArrivedFlights { get; set; }
    }
}
