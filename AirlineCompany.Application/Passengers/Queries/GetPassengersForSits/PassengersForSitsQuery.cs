using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Passengers.Queries.GetPassengersForSits
{
    public class PassengersForSitsQuery:IRequest<PassengersForSitsVm>
    {
        public int FlightId { get; set; }
        public int CurrentSitId { get; set; }
    }
}
