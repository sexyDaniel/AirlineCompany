using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Queries.GetPlaneById
{
    public class GetPlaneByIdQuery:IRequest<PlanesByIdVm>
    {
        public int Id { get; set; }
    }
}
