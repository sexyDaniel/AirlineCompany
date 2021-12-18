using MediatR;
using AirlineCompany.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Captains.Commands.Delete
{
    public class DeleteCaptainCommandHandler : IRequestHandler<DeleteCaptainCommand, bool>
    {
        private IDapperContext context;
        public DeleteCaptainCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(DeleteCaptainCommand request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"delete from PlanesDb.dbo.Captains where id = {request.Id}");

            return true;
        }
    }
}
