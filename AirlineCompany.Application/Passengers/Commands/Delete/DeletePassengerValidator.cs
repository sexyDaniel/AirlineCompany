using FluentValidation;
using AirlineCompany.Application.Interfaces;
using System.Linq;

namespace AirlineCompany.Application.Passengers.Commands.Delete
{
    public class DeletePassengerValidator:AbstractValidator<DeletePassengerCommnad>
    {
        public DeletePassengerValidator(IDapperContext context) 
        {
            RuleFor(deleteCommand => deleteCommand.Id).Must(n =>
            {
                var count = context.GetAsync<int>($"select count(s.id) from Sits as s " +
                    $"where s.passenger_id = '{n}'").Result.First();
                return count == 0;
            }).WithMessage("У пассажира есть рейсы. Невозвожно удалить.");
        }
    }
}
