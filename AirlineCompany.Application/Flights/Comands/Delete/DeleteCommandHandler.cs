using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Comands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteFlightCommand, bool>
    {
        private IDapperContext context;
        public DeleteCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"delete from Flights where id = {request.FlightId}");
            return true;
        }
    }
}
