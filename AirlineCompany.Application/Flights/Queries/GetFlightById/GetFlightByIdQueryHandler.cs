using AirlineCompany.Application.Flights.Queries.GetFlightById.Dtos;
using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetFlightById
{
    public class GetFlightByIdQueryHandler : IRequestHandler<GetFlightByIdQuery, FlightByIdVM>
    {
        private IDapperContext context;
        public GetFlightByIdQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<FlightByIdVM> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
        {
            var flightVm = new FlightByIdVM
            {
                FlightDto = (await context.GetAsync<FlightDtoById>(
                    "select f.arrival_city as ArrivedCityId, f.departure_city as DepartyredCityId, " +
                    "f.arrival_date as ArrivedDate, f.departyre_date as DepartyredDate, f.plane_id as CurrentPlaneId, f.captain_id as CurrentCaptainId, p.row_count as Rows, p.collumn_count as SitsInRows " +
                    "from Flights as f " +
                    "left join PlanesDb.dbo.Planes as p on p.id = f.plane_id " +
                    $"where f.id = {request.Id}")).FirstOrDefault(),

                Cities = await context.GetAsync<CityDto>("select c.id as Id, c.name as Name from Cities as c"),
                Planes = await context.GetAsync<Plane>(
                    "select p.id, p.capacity, m.name as Model from PlanesDb.dbo.Planes as p " +
                    "join PlanesDb.dbo.Models as m on p.model_id = m.id"),

                Captains = await context.GetAsync<Captain>("select c.id , c.last_name as LastName from PlanesDb.dbo.Captains as c"),
                OccupiedPlaces = await context.GetAsync<OccupiedPlace>($"select s.id as SitId, s.row, s.\"column\" as SitInRow, s.passenger_id as PassengerId, p.first_name as FirstName, p.last_name as LastName, p.patronymic from Sits as s left join Passengers as p on p.id = s.passenger_id where flight_id = {request.Id}")
            };

            return flightVm;
        }
    }
}
