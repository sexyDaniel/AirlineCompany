using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Commands.Update
{
    public class UpdatePlaneValidator:AbstractValidator<UpdatePlaneCommand>
    {
        public UpdatePlaneValidator() 
        {
            RuleFor(updateCommand => updateCommand.ModelId)
                .Must(fn => fn != 0)
                .WithMessage("Укажите модель самолета");

            RuleFor(updateCommand => updateCommand.Rows)
                .Must(r => r > 10 && r <= 50)
                .WithMessage("Число рядов должно быть в следующих пределах: от 11 до 50 включительно");

            RuleFor(updateCommand => updateCommand.SitsInRow)
                .Must(с => с >= 4 && с <= 6)
                .WithMessage("Число мест в ряду должно быть в следующих пределах: от 4 до 6 включительно");
        }
    }
}
