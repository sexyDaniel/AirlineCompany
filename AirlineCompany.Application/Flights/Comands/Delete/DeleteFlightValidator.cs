using FluentValidation;
using AirlineCompany.Application.Interfaces;
using System.Linq;

namespace AirlineCompany.Application.Flights.Comands.Delete
{
    public class DeleteFlightValidator:AbstractValidator<DeleteFlightCommand>
    {
        public DeleteFlightValidator(IDapperContext context)
        {
            RuleFor(deleteCommand => deleteCommand.FlightId).Must(n =>
            {
                var count = context.GetAsync<int>($"select count(s.id) from Sits as s " +
                    $"where s.flight_id = {n} and s.passenger_id != 0").Result.First();
                return count == 0;
            }).WithMessage("У рейса есть занятые места. Невозвожно удалить.");
        }
    }
}
