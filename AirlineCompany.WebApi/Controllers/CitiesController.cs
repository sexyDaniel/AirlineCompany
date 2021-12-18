using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AirlineCompany.Application.Cities.Queries.GetCities;
using AirlineCompany.Application.Cities.Queries.GetCityById;
using AirlineCompany.Application.Cities.Commands.Create;
using AirlineCompany.Application.Cities.Commands.Delete;
using AirlineCompany.Application.Cities.Commands.Update;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IMediator mediator;

        public CitiesController(IMediator mediator) => (this.mediator) = (mediator);

        [HttpGet("all")]
        public async Task<CitiesVm> GetCities() 
        {
            var response = await mediator.Send(new GetCitiesQuery());

            return response;
        }

        [HttpGet("sort")]
        public async Task<CitiesVm> Sort(bool byCityName, bool byArrivedCount, bool byDepartureCount)
        {
            var response = await mediator.Send(new GetCitiesQuery() 
            {
                IsSortByCity = byCityName,
                IsSortByArrivedCount = byArrivedCount,
                IsSortByDepartyreCount = byDepartureCount
            });

            return response;
        }

        [HttpGet("search")]
        public async Task<CitiesVm> Search(string cityName)
        {
            var response = await mediator.Send(new GetCitiesQuery() { CityName = cityName});

            return response;
        }

        [HttpGet("{id}")]
        public async Task<CityByIdVm> GetCityById(int id)
        {
            var response = await mediator.Send(new GetCityByIdQuery() {Id = id });

            return response;
        }

        [HttpPost("add")]
        public async Task<bool> Add(CreateCityCommand command)
        {
            var response = await mediator.Send(command);

            return response;
        }

        [HttpDelete("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            var response = await mediator.Send(new DeleteCityCommand() {Id = id });

            return response;
        }

        [HttpPut("update")]
        public async Task<bool> Update(UpdateCityCommnad command)
        {
            var response = await mediator.Send(command);

            return response;
        }
    }
}
