using MediatR;

namespace AirlineCompany.Application.Flights.Queries.GetPlaneFlights
{
    public class GetPlaneFlightsQuery:IRequest<PlaneFlightsVm>
    {
        public int Id { get; set; }
    }
}
