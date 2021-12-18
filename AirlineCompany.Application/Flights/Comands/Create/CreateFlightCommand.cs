using MediatR;
using System;

namespace AirlineCompany.Application.Flights.Comands.Create
{
    public class CreateFlightCommand:IRequest<bool>
    {
        public int DepartyreCity { get; set; }
        public int ArrivedCity { get; set; }
        public DateTime DepartyreDate { get; set; }
        public DateTime ArrivedDate { get; set; }
        public int PlaneId { get; set; }
        public int CaptainId { get; set; }
    }
}
