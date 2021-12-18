using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetFlightForCity
{
    public class GetFlightsForCityQueryHandler : IRequestHandler<GetFlightsForCityQuery, FlightsForCityVm>
    {
        private IDapperContext context;
        public GetFlightsForCityQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<FlightsForCityVm> Handle(GetFlightsForCityQuery request, CancellationToken cancellationToken)
        {
            var response = new FlightsForCityVm()
            {
                DepartyreFlights = await context.GetAsync<FlightsForCityDto>($"select f.id,c.name as DepartureCity,c1.name as ArrivedCity from Flights as f " +
                $"join Cities as c on f.departure_city = c.id " +
                $"join Cities as c1 on f.arrival_city = c1.id " +
                $"where c.id = {request.Id}"),

                ArrivedFlights = await context.GetAsync<FlightsForCityDto>($"select f.id,c.name as DepartureCity,c1.name as ArrivedCity from Flights as f " +
                $"join Cities as c on f.departure_city = c.id " +
                $"join Cities as c1 on f.arrival_city = c1.id " +
                $"where c1.id = {request.Id}")
            };

            return response;
        }
    }
}
