using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Captains.Commands.Create
{
    public class CreateCaptainCommand:IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronomic { get; set; }
    }
}
