using MediatR;

namespace AirlineCompany.Application.Passengers.Queries.GetPassengers
{
    public class GetPassengersQuery:IRequest<PassengerVm>
    {
        public string SearchByFirstName { get; set; }
        public string SearchByLastName { get; set; }
        public string SearchByPatronymic { get; set; }
        public bool SortByFirstName { get; set; }
        public bool SortByLastName { get; set; }
        public bool SortByPatronymic { get; set; }
    }
}
