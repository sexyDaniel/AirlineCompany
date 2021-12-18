using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AirlineCompany.Application.Interfaces;

namespace AirlineCompany.Application.Flights.Comands.Create
{
    public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, bool>
    {
        private IDapperContext context;
        public CreateFlightCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync("insert into Flights (departure_city,arrival_city,arrival_date, departyre_date, plane_id, captain_id) " +
                $"values({request.DepartyreCity},{request.ArrivedCity},'{request.ArrivedDate:g}','{request.DepartyreDate:g}',{request.PlaneId},{request.CaptainId})");
            return true;
        }
    }
}
