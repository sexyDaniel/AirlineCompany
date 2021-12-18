using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Cities.Queries.GetCityById
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityByIdVm>
    {
        private IDapperContext context;
        public GetCityByIdQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<CityByIdVm> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new CityByIdVm()
            {
                City = (await context.GetAsync<CityByIdDto>($"select name from Cities where id = {request.Id}")).FirstOrDefault()
            };

            return response;
        }
    }
}
