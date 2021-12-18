using System;
using FluentValidation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Captains.Commands.Create
{
    public class CreateCaptainValidator:AbstractValidator<CreateCaptainCommand>
    {
        public CreateCaptainValidator() 
        {
            RuleFor(createCommand => createCommand.FirstName)
                .NotEmpty().WithMessage("Введите имя капитана")
                .Length(2,40).WithMessage("Длина имени должна быть от 2 до 40 символов");

            RuleFor(createCommand => createCommand.LastName)
                .NotEmpty().WithMessage("Введите фамилию капитана")
                .Length(2, 40).WithMessage("Длина фамилии должна быть от 2 до 40 символов");

            RuleFor(createCommand => createCommand.Patronomic)
                .NotEmpty().WithMessage("Введите отчество капитана")
                .Length(2, 40).WithMessage("Длина отчества должна быть от 2 до 40 символов");
        }
    }
}
