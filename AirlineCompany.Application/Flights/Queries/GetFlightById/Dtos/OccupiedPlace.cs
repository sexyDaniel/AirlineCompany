using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Queries.GetFlightById.Dtos
{
    public class OccupiedPlace
    {
        public int SitId { get; set; }
        public int Row { get; set; }
        public int SitInRow { get; set; }
        public int PassengerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
    }
}
