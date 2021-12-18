using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Comands.DropCartainFromFlight
{
    public class DropCaptainCommandHandler : IRequestHandler<DropCaptainCommand, bool>
    {
        private IDapperContext context;
        public DropCaptainCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(DropCaptainCommand request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"update Flights set captain_id = 0 where id = {request.FlightId}");
            return true;
        }
    }
}
