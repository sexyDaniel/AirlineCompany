using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Sits.Commands.Update
{
    public class UpdateSitsCommandHandler:IRequestHandler<UpdateSitsCommand,bool>
    {
        private IDapperContext context;
        public UpdateSitsCommandHandler(IDapperContext context) => (this.context) = (context);

        public async Task<bool> Handle(UpdateSitsCommand request, CancellationToken cancellationToken)
        {

            if (request.SitId == 0)
            {
                await context.ExecuteAsync($"update Sits set passenger_id = 0 where flight_id = {request.FlightId} and passenger_id = {request.PassengerId}");
            }
            else 
            {
                await context.ExecuteAsync($"update Sits set passenger_id = {request.PassengerId} where id = {request.SitId}");
            }

            return true;
        }
    }
}
