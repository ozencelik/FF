using FF.Data.Models.Base;
using FF.Data.Models.Teachers;
using System.Collections.Generic;

namespace FF.Data.Models.Classes
{
    public class UpdateClassModel : BaseModel
    {
        public string Name { get; set; }

        public int SchoolId { get; set; }

        public int TeacherId { get; set; }

        public IList<TeacherModel> Teachers { get; set; }
    }
}
