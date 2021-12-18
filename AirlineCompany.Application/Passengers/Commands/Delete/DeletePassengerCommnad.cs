using MediatR;

namespace AirlineCompany.Application.Passengers.Commands.Delete
{
    public class DeletePassengerCommnad :IRequest<bool>
    {
        public int Id { get; set; }
    }
}
