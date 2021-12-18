using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Passengers.Commands.Update
{
    public class UpdatePassengerValidator:AbstractValidator<UpdatePassengerQuery>
    {
        public UpdatePassengerValidator() 
        {
            RuleFor(updateCommand => updateCommand.FirstName)
                .Must(fn => fn?.Length > 2)
                .WithMessage("Длина имени должна быть больше 2 символов")
                .Must(fn => fn?.Length < 40)
                .WithMessage("Длина имени должна быть меньше 40 символов"); ;

            RuleFor(updateCommand => updateCommand.SecondName)
                .Must(sn => sn?.Length > 2)
                .WithMessage("Длина фамилии должна быть больше 2 символов")
                .Must(ln => ln?.Length < 40)
                .WithMessage("Длина фамилии должна быть меньше 40 символов"); ;

            RuleFor(updateCommand => updateCommand.Patronymic)
                .Must(p => p?.Length > 2)
                .WithMessage("Длина Отчества должна быть больше 2 символов")
                .Must(p => p?.Length < 40)
                .WithMessage("Длина Отчества должна быть меньше 40 символов"); ;

            RuleFor(updateCommand => updateCommand.Birthday)
                .Must(b => DateTime.Now.Year - b.Year >= 18)
                .WithMessage("Пассажиру должно быть больше 18");

            RuleFor(updateCommand => updateCommand.Birthday)
               .Must(b => DateTime.Now.Year - b.Year < 100)
               .WithMessage("Пассажиру должно быть меньше ста лет");
        }
    }
}
