using FluentValidation;
using AirlineCompany.Application.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Planes.Commands.Delete
{
    public class DeletePlaneValidator:AbstractValidator<DeletePlaneCommand>
    {
        public DeletePlaneValidator(IDapperContext context) 
        {
            RuleFor(deleteCommand => deleteCommand.Id).Must(n =>
            {
                var count = context.GetAsync<int>($"select count(f.id) from Flights as f " +
                    $"where f.plane_id = {n}").Result.First();
                return count == 0;
            }).WithMessage("У самолета есть рейсы. Невозвожно удалить.");
        }
    }
}
