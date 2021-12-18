using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Cities.Queries.GetCityById
{
    public class GetCityByIdQuery:IRequest<CityByIdVm>
    {
        public int Id { get; set; }
    }
}
