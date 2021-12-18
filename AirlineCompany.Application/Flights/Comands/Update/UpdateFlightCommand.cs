using MediatR;
using System;

namespace AirlineCompany.Application.Flights.Comands.Update
{
    public class UpdateFlightCommand : IRequest<bool>
    {
        public int FlightId { get; set; }
        public int PlaneId { get; set; }
        public int CaptainId { get; set; }
        public int DepartyreCityId { get; set; }
        public int ArrivedCityId { get; set; }
        public DateTime DepartyreDate { get; set; }
        public DateTime ArrivedDate { get; set; }
    }
}
