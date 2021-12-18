using AirlineCompany.Application.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Flights.Comands.Update
{
    public class UpdateFlightValidator:AbstractValidator<UpdateFlightCommand>
    {
        public UpdateFlightValidator(IDapperContext context)
        {
            RuleFor(updateCommand => updateCommand)
                .Must(cc => cc.ArrivedCityId != cc.DepartyreCityId)
                .WithMessage("Город отбытия не должен быть равен городу прибытия");

            RuleFor(updateCommand => updateCommand)
                .Must(cc => cc.DepartyreDate < cc.ArrivedDate)
                .WithMessage("Дата отбытия должна быть меньше даты прибытия");

            RuleFor(updateCommand => updateCommand.PlaneId)
                .Must(id => id != 0)
                .WithMessage("Назначьте самолет на рейс");

            RuleFor(updateCommand => updateCommand.ArrivedCityId)
                .Must(ac => ac != 0)
                .WithMessage("Город прибытия не указан");

            RuleFor(updateCommand => updateCommand.DepartyreCityId)
                .Must(dc => dc != 0)
                .WithMessage("Город отбытия не указан");

            RuleFor(updateCommand => updateCommand.DepartyreDate)
                .Must(dd => dd >= DateTime.Now)
                .WithMessage("Дата отбытия меньше сегодняшней даты");

            RuleFor(updateCommand => updateCommand.ArrivedDate)
                .Must(ad => ad >= DateTime.Now)
                .WithMessage("Дата прибытия меньше сегодняшней даты");
        }
    }
}
