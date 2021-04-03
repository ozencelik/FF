using System;
using System.Collections.Generic;
using System.Text;

namespace FF.Data.Models.SchoolBusses
{
    public class CreateSchoolBusModel
    {
        public string Plate { get; set; }

        public string DriverFirstName { get; set; }

        public string DriverLastName { get; set; }

        public string DriverFullName => $"{DriverFirstName} {DriverLastName}";
    }
}
