using MediatR;
using AirlineCompany.Application.Interfaces;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Captains.Queries.GetCaptainById
{
    public class GetCaptainByidQueryHandler : IRequestHandler<GetCaptainByIdQuery, CaptainVm>
    {
        private IDapperContext context;
        public GetCaptainByidQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<CaptainVm> Handle(GetCaptainByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new CaptainVm()
            {
                CaptainByIdDtos = await context.GetAsync<CaptainByIdDto>($"select c.id, c.last_name as LastName, c.first_name as FirstName, c.patronymic as Patronymic from PlanesDb.dbo.Captains as c " +
                $"where c.id = {request.Id}")
            };

            return response;
        }
    }
}
