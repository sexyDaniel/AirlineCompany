using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AirlineCompany.Application.Interfaces;

namespace AirlineCompany.Application.Flights.Queries.GetFlights
{
    public class GetFlightsQueryHandler : IRequestHandler<GetFlightsQuery, FlightsVm>
    {
        private IDapperContext context;
        private List<string> sortBy = new List<string>();
        private List<string> filters = new List<string>();
        public GetFlightsQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<FlightsVm> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {
            if (request.ArrivedCityId > 0)
            {
                filters.Add($"c1.id = {request.ArrivedCityId}");
            }
            if (request.DepartyreCityId > 0)
            {
                filters.Add($"c.id = {request.DepartyreCityId}");
            }

            if (request.IsSortByDepartyreCity)
                sortBy.Add("DepartureCity");
            if (request.IsSortByArrivedCity)
                sortBy.Add("ArriverCity");
            if (request.IsSortByDepartyreDate)
                sortBy.Add("DepartureDate");
            if (request.IsSortByArribedDate)
                sortBy.Add("ArriverDate");

            var orderString = sortBy.Count > 0 ? $"order by {string.Join(',', sortBy)}" : "";
            var filterString = filters.Count > 0 ? $"where {string.Join(" and ", filters)}" : "";
            var flights = await context.GetAsync<FlightDto>(
                "select f.id as Id, c1.name as ArriverCity, c.name as DepartureCity,f.departyre_date as DepartureDate, f.arrival_date as ArriverDate, " +
                "m.name as CurrentPlane, (cap.last_name + ' ' + cap.first_name) as CurrentCaptain from Flights as f " +
                "join Cities as c on f.arrival_city = c.id " +
                "join Cities as c1 on f.departure_city = c1.id " +
                "join PlanesDb.dbo.Planes as p on p.id = f.plane_id " +
                "left join PlanesDb.dbo.Captains as cap on cap.id = f.captain_id " +
                "join PlanesDb.dbo.Models as m on m.id = p.model_id " +
                 orderString + filterString);

            return new FlightsVm() { Flights = flights };
        }
    }
}
