using MediatR;

namespace AirlineCompany.Application.Cities.Queries.GetCities
{
    public class GetCitiesQuery:IRequest<CitiesVm>
    {
        public bool IsSortByDepartyreCount { get; set; }
        public bool IsSortByArrivedCount { get; set; }
        public bool IsSortByCity { get; set; }
        public string CityName { get; set; }
    }
}
