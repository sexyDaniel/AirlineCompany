using MediatR;

namespace AirlineCompany.Application.Flights.Queries.GetFlights
{
    public class GetFlightsQuery:IRequest<FlightsVm>
    {
        public bool IsSortByDepartyreCity { get; set; }
        public bool IsSortByArrivedCity { get; set; }
        public bool IsSortByDepartyreDate { get; set; }
        public bool IsSortByArribedDate { get; set; }
        public int DepartyreCityId { get; set; }
        public int ArrivedCityId { get; set; }
    }
}
