using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Comands.Delete
{
    public class DeleteFlightCommand:IRequest<bool>
    {
        public int FlightId { get; set; }
    }
}
