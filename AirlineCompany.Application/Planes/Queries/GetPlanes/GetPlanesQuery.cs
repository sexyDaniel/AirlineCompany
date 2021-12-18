using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Queries.GetPlanes
{
    public class GetPlanesQuery:IRequest<PlanesVm>
    {
    }
}
