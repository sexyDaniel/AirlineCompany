using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Captains.Commands.Delete
{
    public class DeleteCaptainCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
