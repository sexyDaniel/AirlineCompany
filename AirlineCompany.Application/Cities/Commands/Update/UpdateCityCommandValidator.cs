using FluentValidation;
using AirlineCompany.Application.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Cities.Commands.Update
{
    public class UpdateCityCommandValidator:AbstractValidator<UpdateCityCommnad>
    {
        public UpdateCityCommandValidator(IDapperContext context) 
        {
            RuleFor(updateCityCommand => updateCityCommand.Name).Must(n =>
            {
                var count = context.GetAsync<int>($"select count(c.id) from Cities as c " +
                    $"where c.name = '{n}'").Result.First();
                return count == 0;
            }).WithMessage("Такой город уже существует");
        }
    }
}
