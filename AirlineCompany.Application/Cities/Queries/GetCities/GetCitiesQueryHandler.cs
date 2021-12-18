using MediatR;
using AirlineCompany.Application.Interfaces;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AirlineCompany.Application.Cities.Queries.GetCities
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, CitiesVm>
    {
        public IDapperContext context;
        private List<string> sortBy = new List<string>();
        private List<string> filters = new List<string>();

        public GetCitiesQueryHandler(IDapperContext context) => (this.context) = (context);

        public async Task<CitiesVm> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty( request.CityName))
            {
                filters.Add($"c.name = '{request.CityName}'");
            }

            if (request.IsSortByArrivedCount)
                sortBy.Add("FlightsIn");
            if (request.IsSortByDepartyreCount)
                sortBy.Add("FlightsOut");
            if (request.IsSortByCity)
                sortBy.Add("c.name");

            var orderString = sortBy.Count > 0 ? $"order by {string.Join(',', sortBy)}" : "";
            var filterString = filters.Count > 0 ? $"where {string.Join(" and ", filters)}" : "";

            var response = new CitiesVm
            {
                Cities = await context.GetAsync<CitiesDto>(
                    "select c.id, c.name, COUNT(f.id) as FlightsIn, count(f1.id) as FlightsOut from Cities as c " +
                "left join Flights as f on c.id = f.arrival_city " +
                "left join Flights as f1 on c.id = f1.departure_city " +
                filterString +
                "group by c.id, c.name " +
                orderString)
            };

            return response;
        }
    }
}
