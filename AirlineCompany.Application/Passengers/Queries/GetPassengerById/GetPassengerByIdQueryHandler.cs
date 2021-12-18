using AirlineCompany.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Passengers.Queries.GetPassengerById
{
    public class GetPassengerByIdQueryHandler : IRequestHandler<GetPassengerByIdQuery, PassengerByIdVm>
    {
        private IDapperContext context;
        public GetPassengerByIdQueryHandler(IDapperContext context) => (this.context) = (context);
        public async Task<PassengerByIdVm> Handle(GetPassengerByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new PassengerByIdVm()
            {
                PassengerByIdDtos = await context.GetAsync<PassengerByIdDto>($"select p.id, p.last_name as LastName, p.first_name as FirstName, p.patronymic as Patronymic, p.birthday from Passengers as p " +
                $"where p.id = {request.PassengerId}")
            };

            return response;
        }

    }
}
