using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Passengers.Queries.GetPassengersForSits
{
    public class PassengersForSitsQueryHandler:IRequestHandler<PassengersForSitsQuery, PassengersForSitsVm>
    {
        private IDapperContext context;
        public PassengersForSitsQueryHandler(IDapperContext context) => (this.context) = (context);

        public async Task<PassengersForSitsVm> Handle(PassengersForSitsQuery request, CancellationToken cancellationToken)
        {
            var response = new PassengersForSitsVm
            {
                FlightId = request.FlightId,
                passengerForSits = await context.GetAsync<PassengerForSitDto>($"select p.id, p.first_name as FirstName,p.last_name as LastName,p.patronymic from Passengers as p " +
                $"where p.id not in " +
                $"(select p1.id from Passengers as p1 join Sits as s on p1.id = s.passenger_id where flight_id = {request.FlightId}) order by LastName"),
                CurrentPassenger = (await context.GetAsync<PassengerForSitDto>($"select p1.id, p1.first_name as FirstName,p1.last_name as LastName,p1.patronymic from Passengers as p1 " +
                $"join Sits as s on s.passenger_id = p1.id " +
                $"where s.id = {request.CurrentSitId}")).FirstOrDefault()
            };

            return response;
        }
    }
}
