using MediatR;

namespace AirlineCompany.Application.Flights.Queries.GetPassengerFlights
{
    public class PassengerFlightsQuery:IRequest<PassengerFlightVm>
    {
        public int PassengerId { get; set; }
    }
}
