using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using AirlineCompany.Application.Flights.Queries.GetFlights;
using AirlineCompany.Application.Flights.Queries.GetFlightById;
using AirlineCompany.Application.Flights.Queries.GetPassengerFlights;
using AirlineCompany.Application.Flights.Queries.GetFlightForCity;
using AirlineCompany.Application.Flights.Comands.Create;
using AirlineCompany.Application.Flights.Comands.Update;
using AirlineCompany.Application.Flights.Comands.Delete;
using AirlineCompany.Application.Flights.Comands.DropCartainFromFlight;
using AirlineCompany.Application.Flights.Queries.GetModelsForCreateFlight;
using AirlineCompany.Application.Flights.Queries.GetCaptainFlights;
using AirlineCompany.Application.Flights.Queries.GetPlaneFlights;

namespace AirlineCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private IMediator mediator;
        public FlightsController(IMediator mediator) => (this.mediator) = (mediator);

        [HttpGet("all")]
        public async Task<FlightsVm> GetFlights(int depCityId,int arrCityId) 
        {
            var response = await mediator.Send( new GetFlightsQuery() 
            {
                DepartyreCityId = depCityId,
                ArrivedCityId = arrCityId
            });
            return response;
        }

        [HttpGet("forCity/{cityId}")]
        public async Task<FlightsForCityVm> GetFlightsForCity(int cityId)
        {
            var response = await mediator.Send(new GetFlightsForCityQuery()
            {
                Id = cityId
            });
            return response;
        }

        [HttpGet("forPlane/{planeId}")]
        public async Task<PlaneFlightsVm> GetFlightsForPlane(int planeId)
        {
            var response = await mediator.Send(new GetPlaneFlightsQuery()
            {
                Id = planeId
            });
            return response;
        }

        [HttpGet("forPassenger/{passengerId}")]
        public async Task<PassengerFlightVm> GetFlightsForPassenger(int passengerId)
        {
            var response = await mediator.Send(new PassengerFlightsQuery()
            {
                PassengerId = passengerId
            });
            return response;
        }

        [HttpGet("forCaptains/{Id}")]
        public async Task<CaptainFlightsVm> GetFlightsForCaptain(int Id)
        {
            var response = await mediator.Send(new GetCaptainFlightsQuery()
            {
                Id = Id
            });
            return response;
        }

        [HttpGet("search")]
        public async Task<FlightsVm> Search(int depCityId, int arrCityId)
        {
            var response = await mediator.Send(new GetFlightsQuery()
            {
                DepartyreCityId = depCityId,
                ArrivedCityId = arrCityId
            });
            return response;
        }

        [HttpGet("forAdd")]
        public async Task<CreateFlightVm> GetVmForAdd() 
        {
            var response = await mediator.Send(new GetModelsForCreateFlightQuery());
            return response;
        }

        [HttpGet("sort")]
        public async Task<FlightsVm> Sort(bool byArrCity, bool byDepCity, bool byDepDate, bool byArrDate)
        {
            var response = await mediator.Send(new GetFlightsQuery() 
            {
                IsSortByArrivedCity = byArrCity,
                IsSortByArribedDate = byArrDate,
                IsSortByDepartyreCity = byDepCity,
                IsSortByDepartyreDate = byDepDate
            });
            return response;
        }

        [HttpGet("{id}")]
        public async Task<FlightByIdVM> GetFlightsById(int id)
        {
            var response = await mediator.Send(new GetFlightByIdQuery() { Id = id});
            return response;
        }

        [HttpPost("add")]
        public async Task<bool> AddFlight(CreateFlightCommand command) 
        {
            var response = await mediator.Send(command);
            return response;
        }

        [HttpPut("update")]
        public async Task<bool> UpdateFlight(UpdateFlightCommand command)
        {
            var response = await mediator.Send(command);
            return response;
        }

        [HttpDelete("delete/{id}")]
        public async Task<bool> DeleteFlight(int id)
        {
            var response = await mediator.Send(new DeleteFlightCommand() { FlightId = id });
            return response;
        }

        [HttpPut("dropCaptain")]
        public async Task<bool> DropCaptain(DropCaptainCommand command)
        {
            var response = await mediator.Send(command);
            return response;
        }
    }
}
