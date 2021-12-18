using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Queries.GetPlaneById
{
    public class PlanesBuIdDto
    {
        public int Rows { get; set; }
        public int SitsInRow { get; set; }
        public int Capacity { get; set; }
        public int ModelId { get; set; }
    }
}
