using MediatR;
using AirlineCompany.Application.Interfaces;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.PlaneModels.Queries.GetModels
{
    public class GetModelsQueryHandler : IRequestHandler<GetModelsQuery, GetModelsVm>
    {
        private IDapperContext context;

        public GetModelsQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<GetModelsVm> Handle(GetModelsQuery request, CancellationToken cancellationToken)
        {
            var vm = new GetModelsVm
            {
                ModelsDtos = await context.GetAsync<GetModelsDto>("select id, name as Model from PlanesDb.dbo.Models ")
            };

            return vm;
        }
    }
}
