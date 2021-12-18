using MediatR;
using AirlineCompany.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace AirlineCompany.Application.Captains.Queries.GetCaptains
{
    public class GetCaptainsQueryHandler : IRequestHandler<GetCaptainsQuery, CaptainsVm>
    {
        private readonly IDapperContext context;
        private List<string> sortBy = new ();
        private List<string> filters = new ();
        public GetCaptainsQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<CaptainsVm> Handle(GetCaptainsQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.SearchByFirstName))
            {
                filters.Add($"c.first_name = '{request.SearchByFirstName}'");
            }
            if (!string.IsNullOrEmpty(request.SearchByLastName))
            {
                filters.Add($"c.last_name = '{request.SearchByLastName}'");
            }
            if (!string.IsNullOrEmpty(request.SearchByPatronymic))
            {
                filters.Add($"c.patronymic = '{request.SearchByPatronymic}'");
            }

            if (request.SortByFirstName)
                sortBy.Add("FirstName");
            if (request.SortByLastName)
                sortBy.Add("LastName");
            if (request.SortByPatronymic)
                sortBy.Add("patronymic");
            if (request.SortByStatus)
                sortBy.Add("FlightCount");

            var orderString = sortBy.Count > 0 ? $"order by {string.Join(',', sortBy)}" : "";
            var filterString = filters.Count > 0 ? $"where {string.Join(" and ", filters)}" : "";
            var response = new CaptainsVm
            {
                Captains = await context.GetAsync<CaptainDto>("select c.id, c.first_name as FirstName, c.last_name as LastName, c.patronymic, COUNT(f.id) as FlightCount from PlanesDb.dbo.Captains as c " +
                "left join Flights as f on f.captain_id = c.id " +
                filterString +
                " group by c.id, c.first_name, c.last_name, c.patronymic "+
                orderString)
            };

            return response;
        }
    }
}
