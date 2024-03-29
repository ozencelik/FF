﻿using FF.Data.Models.Base;
using FF.Data.Models.Schools;
using FF.Data.Models.Students;
using System.Collections.Generic;

namespace FF.Data.Models.SchoolBuses
{
    public class SchoolBusModel : PersonModel
    {
        public int SchoolId { get; set; }

        public SchoolModel School { get; set; }

        public string LicensePlate { get; set; }

        public string PhoneNumber { get; set; }

        public string CompanyName { get; set; }

        public IList<StudentModel> Students { get; set; }
    }
}
