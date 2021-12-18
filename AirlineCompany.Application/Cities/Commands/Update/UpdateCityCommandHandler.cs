using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Cities.Commands.Update
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommnad, bool>
    {
        private IDapperContext context;
        public UpdateCityCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(UpdateCityCommnad request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"update Cities set name = '{request.Name}' where id = {request.Id}");

            return true;
        }
    }
}
