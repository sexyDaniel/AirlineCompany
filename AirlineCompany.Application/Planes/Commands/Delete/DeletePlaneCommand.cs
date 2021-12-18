using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Commands.Delete
{
    public class DeletePlaneCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
