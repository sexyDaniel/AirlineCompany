using MediatR;

namespace AirlineCompany.Application.Flights.Queries.GetFlightById
{
    public class GetFlightByIdQuery:IRequest<FlightByIdVM>
    {
        public int Id { get; set; }
    }
}
