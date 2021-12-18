using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Queries.GetPlaneById
{
    public class PlaneByIdQueryHandler : IRequestHandler<GetPlaneByIdQuery, PlanesByIdVm>
    {
        private readonly IDapperContext context;

        public PlaneByIdQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<PlanesByIdVm> Handle(GetPlaneByIdQuery request, CancellationToken cancellationToken)
        {
            var planesVm = new PlanesByIdVm()
            {
                Plane = (await context.GetAsync<PlanesBuIdDto>("select p.id, p.capacity, p.row_count as Rows, p.collumn_count as SitsInRow, m.id as ModelId from PlanesDb.dbo.Planes as p " +
                "join PlanesDb.dbo.Models as m on m.id = p.model_id")).First()
            };

            return planesVm;
        }
    }
}
