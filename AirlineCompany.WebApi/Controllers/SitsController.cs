using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AirlineCompany.Application.Sits.Commands.Update;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitsController : ControllerBase
    {
        private IMediator mediator;
        public SitsController(IMediator mediator) => (this.mediator) = (mediator);

        [HttpPut("update")]
        public async Task<bool> Update(UpdateSitsCommand command)
        {
            var response = await mediator.Send(command);
            return response;
        }
    }
}
