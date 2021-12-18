using FluentValidation;
using AirlineCompany.Application.Interfaces;
using System.Threading;
using System.Linq;

namespace AirlineCompany.Application.Cities.Commands.Delete
{
    public class DeleteCityCommandValidator : AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityCommandValidator(IDapperContext context) 
        {
            RuleFor(deleteCityCommand => deleteCityCommand.Id).Must( n =>
            {
                var count = context.GetAsync<int>($"select count(f.id) from Flights as f " +
                    $"where f.arrival_city = '{n}' or f.departure_city = {n}").Result.First();
                return count == 0;
            }).WithMessage("В город или из города назначены рейсы. Нельзя удалить.");
        }
    }
}
