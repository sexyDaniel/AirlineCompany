using AirlineCompany.Application.Flights.Queries.GetFlightById.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetFlightById
{
    public class FlightByIdVM
    {
        public List<CityDto> Cities { get; set; }
        
        public FlightDtoById FlightDto { get; set; }
        public List<Plane> Planes { get; set; }
        public List<Captain> Captains { get; set; }
        public List<OccupiedPlace> OccupiedPlaces { get; set; }
        
    }
}
