using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Cities.Queries.GetCities
{
    public class CitiesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FlightsIn { get; set; }
        public int FlightsOut { get; set; }
    }
}
