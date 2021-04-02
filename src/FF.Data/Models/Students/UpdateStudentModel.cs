﻿using FF.Data.Entities.Classes;
using FF.Data.Entities.SchoolBuses;
using System;
using System.Collections.Generic;

namespace FF.Data.Models.Students
{
    public class UpdateStudentModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTime Birthday { get; set; }

        public string ParentFirstName { get; set; }

        public string ParentLastName { get; set; }

        public string ParentPhoneNumber { get; set; }

        public string ParentEmail { get; set; }

        public int ClassId { get; set; }

        public IList<Class> Classes { get; set; }

        public int SchoolBusId { get; set; }

        public IList<SchoolBus> SchoolBuses { get; set; }
    }
}