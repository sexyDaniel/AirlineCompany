using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Captains.Commands.Update
{
    public class UpdateCaptainValidator : AbstractValidator<UpdateCaptainQuery>
    {
        public UpdateCaptainValidator() 
        {
            RuleFor(updateCommand => updateCommand.FirstName)
                .Must(fn => fn?.Length > 2)
                .WithMessage("Длина имени должна быть больше 2 символов")
                .Must(fn => fn?.Length < 40)
                .WithMessage("Длина имени должна быть меньше 40 символов"); ;

            RuleFor(updateCommand => updateCommand.LastName)
                .Must(sn => sn?.Length > 2)
                .WithMessage("Длина фамилии должна быть больше 2 символов")
                .Must(ln => ln?.Length < 40)
                .WithMessage("Длина фамилии должна быть меньше 40 символов"); ;

            RuleFor(updateCommand => updateCommand.Patronymic)
                .Must(p => p?.Length > 2)
                .WithMessage("Длина Отчества должна быть больше 2 символов")
                .Must(p => p?.Length < 40)
                .WithMessage("Длина Отчества должна быть меньше 40 символов"); ;

        }

    }
}
