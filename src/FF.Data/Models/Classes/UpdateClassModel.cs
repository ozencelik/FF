using FF.Data.Models.Base;

namespace FF.Data.Models.Classes
{
    public class UpdateClassModel : BaseModel
    {
        public string Name { get; set; }

        public int SchoolId { get; set; }

        public int TeacherId { get; set; }
    }
}
