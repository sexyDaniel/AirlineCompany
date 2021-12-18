using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Passengers.Commands.Delete
{
    public class DeletePassengerCommandHandler: IRequestHandler<DeletePassengerCommnad, bool>
    {
        private IDapperContext context;
        public DeletePassengerCommandHandler(IDapperContext context) => (this.context) = (context);

        public async Task<bool> Handle(DeletePassengerCommnad request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"delete from Passengers " +
                $"where id = {request.Id}");

            return true;
        }
    }
}
