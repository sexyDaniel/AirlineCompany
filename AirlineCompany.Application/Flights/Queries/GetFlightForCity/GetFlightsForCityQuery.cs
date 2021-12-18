using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetFlightForCity
{
    public class GetFlightsForCityQuery:IRequest<FlightsForCityVm>
    {
        public int Id { get; set; }
    }
}
