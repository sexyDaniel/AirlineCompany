using MediatR;
using AirlineCompany.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Queries.GetPlanes
{
    public class GetPlanesQueryHandler : IRequestHandler<GetPlanesQuery, PlanesVm>
    {
        private readonly IDapperContext context;

        public GetPlanesQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<PlanesVm> Handle(GetPlanesQuery request, CancellationToken cancellationToken)
        {
            var planesVm = new PlanesVm()
            {
                Planes = await context.GetAsync<PlaneDto>("select p.id, p.capacity, p.row_count as Rows, p.collumn_count as SitsInRow, m.name as Model, count(f.id) as FlightsCount from PlanesDb.dbo.Planes as p " +
                "join PlanesDb.dbo.Models as m on m.id = p.model_id " +
                "left join Flights as f on f.plane_id = p.id " +
                "group by p.id, p.capacity, p.row_count, p.collumn_count, m.name")
            };

            return planesVm;
        }
    }
}
