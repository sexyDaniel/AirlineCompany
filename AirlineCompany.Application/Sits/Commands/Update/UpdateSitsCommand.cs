using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Sits.Commands.Update
{
    public class UpdateSitsCommand:IRequest<bool>
    {
        public int FlightId { get; set; }
        public int PassengerId { get; set; }

        public int SitId { get; set; }
    }
}
