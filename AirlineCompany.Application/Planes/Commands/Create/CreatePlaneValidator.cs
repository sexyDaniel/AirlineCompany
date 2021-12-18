using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Commands.Create
{
    public class CreatePlaneValidator:AbstractValidator<CreatePlaneCommand>
    {
        public CreatePlaneValidator() 
        {
            RuleFor(deleteCommand => deleteCommand.ModelId)
                .Must(fn => fn !=0 )
                .WithMessage("Укажите модель самолета");

            RuleFor(deleteCommand => deleteCommand.Rows)
                .Must(r => r > 10 && r<= 50)
                .WithMessage("Число рядов должно быть в следующих пределах: от 11 до 50 включительно");

            RuleFor(deleteCommand => deleteCommand.SitsInRow)
                .Must(с => с >= 4 && с <= 6)
                .WithMessage("Число мест в ряду должно быть в следующих пределах: от 4 до 6 включительно");
        }
    }
}
