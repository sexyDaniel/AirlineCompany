using MediatR;

namespace AirlineCompany.Application.Flights.Comands.DropCartainFromFlight
{
    public class DropCaptainCommand:IRequest<bool>
    {
        public int FlightId { get; set; }
    }
}
