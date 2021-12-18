using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Captains.Queries.GetCaptainById
{
    public class GetCaptainByIdQuery:IRequest<CaptainVm>
    {
        public int Id { get; set; }
    }
}
