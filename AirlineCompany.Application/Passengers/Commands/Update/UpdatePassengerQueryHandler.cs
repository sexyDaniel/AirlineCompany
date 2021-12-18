using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Passengers.Commands.Update
{
    class UpdatePassengerQueryHandler : IRequestHandler<UpdatePassengerQuery, bool>
    {
        private IDapperContext context;
        public UpdatePassengerQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(UpdatePassengerQuery request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"update Passengers set " +
                $"first_name = '{request.FirstName}', " +
                $"last_name = '{request.SecondName}'," +
                $"birthday = '{request.Birthday:d}'," +
                $"patronymic = '{request.Patronymic}' " +
                $"where id = {request.Id}");

            return true;
        }
    }
}
