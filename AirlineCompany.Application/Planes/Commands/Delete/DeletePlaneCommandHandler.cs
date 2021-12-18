using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Commands.Delete
{
    public class DeletePlaneCommandHandler : IRequestHandler<DeletePlaneCommand, bool>
    {
        private readonly IDapperContext context;
        public DeletePlaneCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(DeletePlaneCommand request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"delete from PlanesDb.dbo.Planes " +
               $"where id = {request.Id}");

            return true;
        }
    }
}
