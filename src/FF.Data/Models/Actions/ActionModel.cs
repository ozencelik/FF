using FF.Data.Models.Activities;
using FF.Data.Models.Base;
using FF.Data.Models.Students;
using System.Collections.Generic;

namespace FF.Data.Models.Actions
{
    public class ActionModel : BaseModel
    {
        public int ActivityId { get; set; }

        public ActivityModel Activity { get; set; }

        public IList<StudentModel> Students { get; set; }

        public IList<StudentActivityModel> StudentActivities { get; set; }
    }
}
