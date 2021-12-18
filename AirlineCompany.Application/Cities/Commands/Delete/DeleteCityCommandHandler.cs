using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Cities.Commands.Delete
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, bool>
    {
        private IDapperContext context;
        public DeleteCityCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"delete from Cities where id = {request.Id}");

            return true;
        }
    }
}
