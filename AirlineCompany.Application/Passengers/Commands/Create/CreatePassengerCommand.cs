using MediatR;
using System;

namespace AirlineCompany.Application.Passengers.Commands.Create
{
    public class CreatePassengerCommand:IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Patronomic { get; set; }
    }
}
