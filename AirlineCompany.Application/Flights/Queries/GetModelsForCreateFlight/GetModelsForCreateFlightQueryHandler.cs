using System.Threading;
using System.Threading.Tasks;
using AirlineCompany.Application.Common.DtosForAdd;
using AirlineCompany.Application.Interfaces;
using MediatR;

namespace AirlineCompany.Application.Flights.Queries.GetModelsForCreateFlight
{
    public class GetModelsForCreateFlightQueryHandler : IRequestHandler<GetModelsForCreateFlightQuery, CreateFlightVm>
    {
        private IDapperContext context;
        public GetModelsForCreateFlightQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<CreateFlightVm> Handle(GetModelsForCreateFlightQuery request, CancellationToken cancellationToken)
        {
            var response = new CreateFlightVm()
            {
                Captains = await context.GetAsync<CaptainForAdd>("select c.id, c.first_name as FirstName, c.last_name as LastName, c.patronymic from PlanesDb.dbo.Captains as c"),

                Planes = await context.GetAsync<PlaneForAdd>("select p.id, p.capacity, m.name as Model from PlanesDb.dbo.Planes as p " +
                "join PlanesDb.dbo.Models as m on m.id = p.model_id"),

                Cities = await context.GetAsync<CityForAdd>("select c.id, c.name from Cities as c")
            };

            return response;
        }
    }
}
