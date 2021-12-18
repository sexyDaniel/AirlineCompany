using System.Linq;
using FluentValidation;
using AirlineCompany.Application.Interfaces;

namespace AirlineCompany.Application.Cities.Commands.Create
{
    public class CreateCityCommandValidator:AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator(IDapperContext context) 
        {
            RuleFor(createCityCommand => createCityCommand.Name).NotEmpty().WithMessage("Название города пусто");
            RuleFor(createCityCommand => createCityCommand.Name).MinimumLength(2).WithMessage("Название города содержит меньше 2-х символов");
            RuleFor(createCityCommand => createCityCommand.Name).Must(n =>
            {
                foreach (var c in n) 
                {
                    if (!char.IsLetter(c)) 
                    {
                        return false;
                    }
                }
                return true;
            }).WithMessage("Название содержит лишние символы");

            RuleFor(createCityCommand => createCityCommand.Name).Must(n =>
            {
                var count = context.GetAsync<int>($"select count(c.id) from Cities as c where name = '{n}'").Result.First();
                return count == 0;
            }).WithMessage("Такой город уже существует");
        }
    }
}
