using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Commands.Update
{
    public class UpdatePlaneCommandHandler : IRequestHandler<UpdatePlaneCommand, bool>
    {
        private IDapperContext context;
        public UpdatePlaneCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(UpdatePlaneCommand request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"update PlanesDb.dbo.Planes set " +
                $"capacity={request.Capacity}," +
                $"row_count={request.Rows}," +
                $"collumn_count={request.SitsInRow}," +
                $"model_id={request.ModelId} where id = {request.Id}");

            return true;
        }
    }
}
