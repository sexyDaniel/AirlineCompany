using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetPlaneFlights
{
    public class GetPlaneFlightsQueryHandler : IRequestHandler<GetPlaneFlightsQuery, PlaneFlightsVm>
    {
        private readonly IDapperContext context;
        public GetPlaneFlightsQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<PlaneFlightsVm> Handle(GetPlaneFlightsQuery request, CancellationToken cancellationToken)
        {
            var response = new PlaneFlightsVm()
            {
                PlaneFlightsDtos = await context.GetAsync<PlaneFlightsDto>(
                $"select f.id,c.name as DepartyreCity,c1.name as ArrivedCity from Flights as f " +
                $"join Cities as c on f.departure_city = c.id " +
                $"join Cities as c1 on f.arrival_city = c1.id " + 
                $"where f.plane_id = {request.Id}")
            };

            return response;
        }
    }
}
