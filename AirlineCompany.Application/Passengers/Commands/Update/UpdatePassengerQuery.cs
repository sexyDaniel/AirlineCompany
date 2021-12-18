using MediatR;
using System;

namespace AirlineCompany.Application.Passengers.Commands.Update
{
    public class UpdatePassengerQuery:IRequest<bool>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
    }
}
