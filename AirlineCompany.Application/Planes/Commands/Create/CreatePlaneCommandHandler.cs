using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Commands.Create
{
    class CreatePlaneCommandHandler : IRequestHandler<CreatePlaneCommand, bool>
    {
        private IDapperContext context;
        public CreatePlaneCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(CreatePlaneCommand request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"insert into PlanesDb.dbo.Planes (capacity, row_count, collumn_count, model_id)" +
                $"values ({request.Capacity}, {request.Rows}, {request.SitsInRow}, {request.ModelId})");

            return true;
        }
    }
}
