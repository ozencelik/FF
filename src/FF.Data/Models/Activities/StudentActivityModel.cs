using FF.Data.Models.Actions;
using FF.Data.Models.Students;

namespace FF.Data.Models.Activities
{
    public class StudentActivityModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ActionId { get; set; }

        public ActionModel Action { get; set; }

        public int ActivityOptionId { get; set; }

        public ActivityOptionModel ActivityOption { get; set; }

        public int StudentId { get; set; }

        public StudentModel Student { get; set; }
    }
}
