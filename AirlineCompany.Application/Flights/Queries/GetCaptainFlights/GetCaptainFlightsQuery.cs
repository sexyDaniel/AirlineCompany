using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetCaptainFlights
{
    public class GetCaptainFlightsQuery:IRequest<CaptainFlightsVm>
    {
        public int Id { get; set; }
    }
}
