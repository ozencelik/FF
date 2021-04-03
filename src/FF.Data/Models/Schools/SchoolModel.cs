using FF.Data.Models.Base;
using FF.Data.Models.Classes;
using FF.Data.Models.SchoolBuses;
using FF.Data.Models.Teachers;
using System.Collections.Generic;

namespace FF.Data.Models.Schools
{
    public class SchoolModel : BaseModel
    {
        public string Name { get; set; }

        public IList<ClassModel> Classes { get; set; }

        public IList<SchoolBusModel> SchoolBuses { get; set; }

        public IList<TeacherModel> Teachers { get; set; }
    }
}
