using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Passengers.Queries.GetPassengers
{
    public class GetPassengersQueryHandler : IRequestHandler<GetPassengersQuery, PassengerVm>
    {
        private IDapperContext context;
        private List<string> sortBy = new();
        private List<string> filters = new();
        public GetPassengersQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<PassengerVm> Handle(GetPassengersQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.SearchByFirstName))
            {
                filters.Add($"p.first_name = '{request.SearchByFirstName}'");
            }
            if (!string.IsNullOrEmpty(request.SearchByLastName))
            {
                filters.Add($"p.last_name = '{request.SearchByLastName}'");
            }
            if (!string.IsNullOrEmpty(request.SearchByPatronymic))
            {
                filters.Add($"p.patronymic = '{request.SearchByPatronymic}'");
            }

            if (request.SortByFirstName)
                sortBy.Add("FirstName");
            if (request.SortByLastName)
                sortBy.Add("LastName");
            if (request.SortByPatronymic)
                sortBy.Add("Patronymic");

            var orderString = sortBy.Count > 0 ? $"\norder by {string.Join(',', sortBy)} " : "";
            var filterString = filters.Count > 0 ? $"\nwhere {string.Join(" and ", filters)} " : "";
            var response = new PassengerVm()
            {
                Passengers = await context.GetAsync<PassengerDto>("select p.id, p.last_name as LastName, p.first_name as FirstName, p.patronymic as Patronymic, count(s.passenger_id) as FlightsCount from Passengers as p " +
                "left join Sits as s on p.id = s.passenger_id " +
                filterString +
                "group by p.id, p.last_name, p.last_name, p.first_name, p.patronymic " + 
                orderString)
            };
            return response;
        }
    }
}
