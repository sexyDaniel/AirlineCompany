using FluentValidation;
using AirlineCompany.Application.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Captains.Commands.Delete
{
    public class DeleteCaptainValidator:AbstractValidator<DeleteCaptainCommand>
    {
        public DeleteCaptainValidator(IDapperContext context) 
        {
            RuleFor(deleteCommand => deleteCommand.Id).Must(id =>
            {
                var count = context.GetAsync<int>($"select count(f.id) from Flights as f " +
                    $"where f.captain_id = '{id}'").Result.First();
                return count == 0;
            }).WithMessage("У капитана есть рейсы. Невозвожно удалить.");
        }
    }
}
