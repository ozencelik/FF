using FF.Data.Models.Base;
using FF.Data.Models.Classes;
using FF.Data.Models.SchoolBuses;
using System.Collections.Generic;

namespace FF.Data.Models.Students
{
    public class UpdateStudentModel : PersonModel
    {
        public string ParentFirstName { get; set; }

        public string ParentLastName { get; set; }

        public string ParentPhoneNumber { get; set; }

        public string ParentEmail { get; set; }

        public int ClassId { get; set; }

        public IList<ClassModel> Classes { get; set; }

        public int SchoolBusId { get; set; }

        public IList<SchoolBusModel> SchoolBuses { get; set; }
    }
}
