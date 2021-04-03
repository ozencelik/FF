using FF.Data.Models.Activities;
using FF.Data.Models.Base;
using FF.Data.Models.Classes;
using FF.Data.Models.SchoolBuses;
using System.Collections.Generic;

namespace FF.Data.Models.Students
{
    public class StudentModel : PersonModel
    {
        public int ClassId { get; set; }

        public ClassModel Class { get; set; }

        public int SchoolBusId { get; set; }

        public SchoolBusModel SchoolBus { get; set; }

        public string ParentFirstName { get; set; }

        public string ParentLastName { get; set; }

        public string ParentPhoneNumber { get; set; }

        public string ParentEmail { get; set; }

        public string ProfileAccessCode { get; set; }

        public IList<StudentActivityModel> StudentActivities { get; set; }
    }
}
