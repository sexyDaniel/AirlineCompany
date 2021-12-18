using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetFlightById.Dtos
{
    public class Plane
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Model { get; set; }
    }
}
