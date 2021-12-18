using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetPassengerFlights
{
    public class PassengerFlightsQueryHandler : IRequestHandler<PassengerFlightsQuery, PassengerFlightVm>
    {
        private IDapperContext context;
        public PassengerFlightsQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<PassengerFlightVm> Handle(PassengerFlightsQuery request, CancellationToken cancellationToken)
        {
            var response = new PassengerFlightVm()
            {
                PassengerFlightDtos = await context.GetAsync<PassengerFlightDto>($"select f.id,c.name as DepartyreCity,c1.name as ArrivedCity from Flights as f " +
                $"join Cities as c on f.departure_city = c.id " +
                $"join Cities as c1 on f.arrival_city = c1.id " +
                $"join Sits as s on s.flight_id = f.id " +
                $"where s.passenger_id = {request.PassengerId}")
            };

            return response;
        }
    }
}
