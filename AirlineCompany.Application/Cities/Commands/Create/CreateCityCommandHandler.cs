using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Cities.Commands.Create
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, bool>
    {
        private IDapperContext context;
        public CreateCityCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"insert into Cities (name) values ('{request.Name}')");

            return true;
        }
    }
}
