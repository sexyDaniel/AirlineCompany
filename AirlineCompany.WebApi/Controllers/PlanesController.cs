using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AirlineCompany.Application.Planes.Queries.GetPlanes;
using AirlineCompany.Application.Planes.Queries.GetPlaneById;
using AirlineCompany.Application.Planes.Commands.Create;
using AirlineCompany.Application.Planes.Commands.Update;
using AirlineCompany.Application.Planes.Commands.Delete;
using System.Threading.Tasks;

namespace AirlineCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanesController : ControllerBase
    {
        private readonly IMediator mediat;

        public PlanesController(IMediator mediat) => (this.mediat) = (mediat);

        [HttpGet("all")]
        public async Task<PlanesVm> GetPlanes() 
        {
            var response = await mediat.Send(new GetPlanesQuery());
            return response;
        }

        [HttpGet("{id}")]
        public async Task<PlanesByIdVm> GetPlanesById(int id)
        {
            var response = await mediat.Send(new GetPlaneByIdQuery() { Id = id});
            return response;
        }

        [HttpPost("add")]
        public async Task<bool> Add(CreatePlaneCommand command)
        {
            var response = await mediat.Send(command);
            return response;
        }

        [HttpDelete("delete/{id}")]
        public async Task<bool> Delete(int id)
        {
            var response = await mediat.Send(new DeletePlaneCommand { Id = id});
            return response;
        }

        [HttpPut("update")]
        public async Task<bool> Update(UpdatePlaneCommand command)
        {
            var response = await mediat.Send(command);
            return response;
        }
    }
}
