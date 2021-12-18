using MediatR;

namespace AirlineCompany.Application.Passengers.Queries.GetPassengerById
{
    public class GetPassengerByIdQuery:IRequest<PassengerByIdVm>
    {
        public int PassengerId { get; set; }
    }
}
