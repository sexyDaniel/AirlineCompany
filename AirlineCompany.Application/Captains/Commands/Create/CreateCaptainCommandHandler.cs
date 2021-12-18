using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Captains.Commands.Create
{
    public class CreateCaptainCommandHandler : IRequestHandler<CreateCaptainCommand, bool>
    {
        private IDapperContext context;
        public CreateCaptainCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(CreateCaptainCommand request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"insert into PlanesDb.dbo.Captains (first_name, last_name, patronymic)" +
                $"values ('{request.FirstName}','{request.LastName}','{request.Patronomic}')");

            return true;
        }
    }
}
