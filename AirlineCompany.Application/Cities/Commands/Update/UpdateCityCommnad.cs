using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Cities.Commands.Update
{
    public class UpdateCityCommnad:IRequest<bool>
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
