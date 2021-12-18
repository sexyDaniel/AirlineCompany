﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCompany.Application.Passengers.Queries.GetPassengers
{
    public class PassengerDto
    {
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int FlightsCount { get; set; }
    }
}
