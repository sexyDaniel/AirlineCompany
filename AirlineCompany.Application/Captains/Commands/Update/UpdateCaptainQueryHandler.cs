using MediatR;
using AirlineCompany.Application.Interfaces;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Captains.Commands.Update
{
    public class UpdateCaptainQueryHandler : IRequestHandler<UpdateCaptainQuery, bool>
    {
        private IDapperContext context;
        public UpdateCaptainQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(UpdateCaptainQuery request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"update PlanesDb.dbo.Captains set " +
                $"first_name = '{request.FirstName}', " +
                $"last_name = '{request.LastName}'," +
                $"patronymic = '{request.Patronymic}' " +
                $"where id = {request.Id}");

            return true;
        }
    }
}
