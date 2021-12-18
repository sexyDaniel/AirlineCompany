using MediatR;
using Microsoft.AspNetCore.Mvc;
using AirlineCompany.Application.PlaneModels.Queries.GetModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirlineCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ModelsController(IMediator mediator) => (this.mediator) = (mediator);
        
        [HttpGet("all")]
        public async Task<GetModelsVm> Get()
        {
            var response = await mediator.Send(new GetModelsQuery());
            return response;
        }

    }
}
