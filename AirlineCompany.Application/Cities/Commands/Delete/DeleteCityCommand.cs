using MediatR;

namespace AirlineCompany.Application.Cities.Commands.Delete
{
    public class DeleteCityCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
