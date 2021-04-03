using FF.Data.Models.Base;
using FF.Data.Models.Schools;
using FF.Data.Models.Teachers;

namespace FF.Data.Models.Classes
{
    public class ClassModel : BaseModel
    {
        public string Name { get; set; }

        public int SchoolId { get; set; }

        public SchoolModel School { get; set; }

        public int TeacherId { get; set; }

        public TeacherModel Teacher { get; set; }
    }
}
