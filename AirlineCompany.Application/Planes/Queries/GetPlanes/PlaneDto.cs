using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Queries.GetPlanes
{
    public class PlaneDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Rows { get; set; }
        public int SitsInRow { get; set; }
        public int FlightsCount { get; set; }
    }
}
