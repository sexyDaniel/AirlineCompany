using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Passengers.Commands.Create
{
    public class CreatePassengerCommandHandler : IRequestHandler<CreatePassengerCommand, bool>
    {
        private IDapperContext context;
        public CreatePassengerCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(CreatePassengerCommand request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"insert into Passengers (last_name,first_name,patronymic, birthday) values ('{request.LastName}','{request.FirstName}','{request.Patronomic}','{request.Birthday}')");
            return true;
        }
    }
}
