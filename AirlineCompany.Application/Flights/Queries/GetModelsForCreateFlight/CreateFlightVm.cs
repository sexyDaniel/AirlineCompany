using AirlineCompany.Application.Common.DtosForAdd;
using System.Collections.Generic;

namespace AirlineCompany.Application.Flights.Queries.GetModelsForCreateFlight
{
    public class CreateFlightVm
    {
        public List<CaptainForAdd> Captains { get; set; }
        public List<PlaneForAdd> Planes { get; set; }
        public List<CityForAdd> Cities { get; set; }
    }
}
