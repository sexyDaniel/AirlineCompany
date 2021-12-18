using System.Collections.Generic;

namespace AirlineCompany.Application.Passengers.Queries.GetPassengersForSits
{
    public class PassengersForSitsVm
    {
        public List<PassengerForSitDto> passengerForSits { get; set; }
        public PassengerForSitDto CurrentPassenger { get; set; }
        public int FlightId { get; set; }
        public int CurrentSit { get; set; }
    }
}
