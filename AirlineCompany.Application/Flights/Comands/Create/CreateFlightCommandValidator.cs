using FluentValidation;
using AirlineCompany.Application.Interfaces;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace AirlineCompany.Application.Flights.Comands.Create
{
    public class CreateFlightCommandValidator:AbstractValidator<CreateFlightCommand>
    {
        public CreateFlightCommandValidator(IDapperContext context) 
        {
            RuleFor(createCommand => createCommand)
                .Must(cc => cc.ArrivedCity != cc.DepartyreCity)
                .WithMessage("Город отбытия не должен быть равен городу прибытия");

            RuleFor(createCommand => createCommand)
                .Must(cc => cc.DepartyreDate < cc.ArrivedDate)
                .WithMessage("Дата отбытия должна быть меньше даты прибытия");

            RuleFor(createCommand => createCommand.PlaneId)
                .Must(id => id != 0)
                .WithMessage("Назначьте самолет на рейс");

            RuleFor(createCommand => createCommand.ArrivedCity)
                .Must(ac => ac != 0)
                .WithMessage("Город прибытия не указан");

            RuleFor(createCommand => createCommand.DepartyreCity)
                .Must(dc => dc != 0)
                .WithMessage("Город отбытия не указан");

            RuleFor(createCommand => createCommand.DepartyreDate)
                .Must(dd => dd >= DateTime.Now)
                .WithMessage("Дата отбытия меньше сегодняшней даты");

            RuleFor(createCommand => createCommand.ArrivedDate)
                .Must(ad => ad >= DateTime.Now)
                .WithMessage("Дата прибытия меньше сегодняшней даты");
        }
    }
}
