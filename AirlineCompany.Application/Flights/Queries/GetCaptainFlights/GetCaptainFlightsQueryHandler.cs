using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetCaptainFlights
{
    public class GetCaptainFlightsQueryHandler : IRequestHandler<GetCaptainFlightsQuery, CaptainFlightsVm>
    {
        private IDapperContext context;
        public GetCaptainFlightsQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<CaptainFlightsVm> Handle(GetCaptainFlightsQuery request, CancellationToken cancellationToken)
        {
            var response = new CaptainFlightsVm()
            {
                CaptainFlightDtos = await context.GetAsync<CaptainFlightDto>($"select f.id,c.name as DepartyreCity,c1.name as ArrivedCity from Flights as f " +
                $"join Cities as c on f.departure_city = c.id " +
                $"join Cities as c1 on f.arrival_city = c1.id " +
                $"where f.captain_id = {request.Id}")
            };

            return response;
        }
    }
}
