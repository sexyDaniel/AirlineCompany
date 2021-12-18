using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Commands.Update
{
    public class UpdatePlaneCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int Rows { get; set; }
        public int SitsInRow { get; set; }
        public int Capacity { get; set; }
    }
}
