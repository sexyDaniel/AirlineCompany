using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetFlightById.Dtos
{
    public class FlightDtoById
    {
        public int FlightId { get; set; }
        public int ArrivedCityId { get; set; }
        public int DepartyredCityId { get; set; }
        public DateTime ArrivedDate { get; set; }
        public DateTime DepartyredDate { get; set; }
        public int CurrentPlaneId { get; set; }
        public int Rows { get; set; }
        public int SitsInRows { get; set; }
        public int CurrentCaptainId { get; set; }
    }
}
