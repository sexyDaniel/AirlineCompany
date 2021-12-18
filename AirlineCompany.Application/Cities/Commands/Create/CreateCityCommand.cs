using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Cities.Commands.Create
{
    public class CreateCityCommand:IRequest<bool>
    {
        public string Name { get; set; }
    }
}
