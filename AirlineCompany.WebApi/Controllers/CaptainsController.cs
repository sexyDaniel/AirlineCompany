using Microsoft.AspNetCore.Mvc;
using MediatR;
using AirlineCompany.Application.Captains.Queries.GetCaptains;
using AirlineCompany.Application.Captains.Queries.GetCaptainById;
using AirlineCompany.Application.Captains.Commands.Create;
using AirlineCompany.Application.Captains.Commands.Update;
using AirlineCompany.Application.Captains.Commands.Delete;
using System.Threading.Tasks;

namespace AirlineCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaptainsController : ControllerBase
    {
        private readonly IMediator mediator;
        public CaptainsController(IMediator mediator) => (this.mediator) = (mediator);

        [HttpGet("all")]
        public async Task<CaptainsVm> GetCaptains()
        {
            var response = await mediator.Send(new GetCaptainsQuery());
            return response;
        }

        [HttpGet("{id}")]
        public async Task<CaptainVm> GetPassengersById(int id)
        {
            var response = await mediator.Send(new GetCaptainByIdQuery { Id = id });

            return response;
        }

        [HttpGet("sort")]
        public async Task<CaptainsVm> Sort(bool byFirstName, bool byLastName, bool byPatronymic, bool byStatus)
        {
            var response = await mediator.Send(new GetCaptainsQuery()
            {
                SortByFirstName = byFirstName,
                SortByLastName = byLastName,
                SortByPatronymic = byPatronymic,
                SortByStatus = byStatus
            });
            return response;
        }

        [HttpGet("search")]
        public async Task<CaptainsVm> Search(string byFirstName, string byLastName, string byPatronymic)
        {
            var response = await mediator.Send(new GetCaptainsQuery()
            {
                SearchByFirstName = byFirstName,
                SearchByLastName = byLastName,
                SearchByPatronymic = byPatronymic,
            });
            return response;
        }

        [HttpPost("add")]
        public async Task<bool> Add(CreateCaptainCommand command)
        {
            var response = await mediator.Send(command);
            return response;
        }

        [HttpPut("update")]
        public async Task<bool> Update(UpdateCaptainQuery command)
        {
            var response = await mediator.Send(command);
            return response;
        }

        [HttpDelete("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            var response = await mediator.Send(new DeleteCaptainCommand { Id = id});
            return response;
        }
    }
}
