using AirlineCompany.Application.Passengers.Queries.GetPassengers;
using AirlineCompany.Application.Passengers.Queries.GetPassengersForSits;
using AirlineCompany.Application.Passengers.Queries.GetPassengerById;
using AirlineCompany.Application.Passengers.Commands.Create;
using AirlineCompany.Application.Passengers.Commands.Update;
using AirlineCompany.Application.Passengers.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AirlineCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private IMediator mediator;
        public PassengersController(IMediator mediator) => (this.mediator) = (mediator);

        [HttpGet("all")]
        public async Task<PassengerVm> GetPassengers() 
        {
            var response = await mediator.Send(new GetPassengersQuery());
            return response;
        }

        [HttpGet("sort")]
        public async Task<PassengerVm> Sort(bool byFirstName, bool byLastName, bool byPatronymic)
        {
            var response = await mediator.Send(new GetPassengersQuery() 
            {
                SortByFirstName = byFirstName,
                SortByLastName = byLastName,
                SortByPatronymic = byPatronymic
            });
            return response;
        }

        [HttpGet("search")]
        public async Task<PassengerVm> Search(string firstName, string lastName, string patronymic)
        {
            var response = await mediator.Send(new GetPassengersQuery() 
            { 
                SearchByFirstName = firstName,
                SearchByLastName = lastName,
                SearchByPatronymic = patronymic
            });
            return response;
        }

        [HttpGet("forSits")]
        public async Task<PassengersForSitsVm> GetPassengersForSits(int flightId, int currentSitId)
        {
            var response = await mediator.Send(new PassengersForSitsQuery() 
            { 
                FlightId = flightId,
                CurrentSitId = currentSitId
            });
            return response;
        }

        [HttpGet("{id}")]
        public async Task<PassengerByIdVm> GetPassengersById(int id)
        {
            var response = await mediator.Send(new GetPassengerByIdQuery { PassengerId = id});

            return response;
        }

        [HttpPost("add")]
        public async Task<bool> AddPassenger(CreatePassengerCommand command)
        {
            var response = await mediator.Send(command);
            return response;
        }

        [HttpDelete("delete/{id}")]
        public async Task<bool> DeletePassenger(int id)
        {
            var response = await mediator.Send(new DeletePassengerCommnad { Id = id });
            return response;
        }

        [HttpPut("update")]
        public async Task<bool> UpdatePassenger(UpdatePassengerQuery command)
        {
            var response = await mediator.Send(command);
            return response;
        }
    }
}
