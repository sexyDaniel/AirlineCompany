using MediatR;
using AirlineCompany.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Comands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateFlightCommand, bool>
    {
        private IDapperContext context;
        public UpdateCommandHandler(IDapperContext context) => (this.context) = (context);
        public async Task<bool> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            await context.ExecuteAsync($"update Flights set " +
                $"plane_id = {request.PlaneId}, " +
                $"captain_id = {request.CaptainId}," +
                $"departure_city = {request.DepartyreCityId}," +
                $"arrival_city = {request.ArrivedCityId}," +
                $"departyre_date = '{request.DepartyreDate}'," +
                $"arrival_date = '{request.ArrivedDate}'" +
                $"where id = {request.FlightId}");
            return true;
        }
    }
}
