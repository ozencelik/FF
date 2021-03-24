using FF.Data.Models.Activities;
using System.Collections.Generic;

namespace FF.Data.Models.Actions
{
    public class ActionModel
    {
        public int Id { get; set; }

        public int ActivityId { get; set; }

        public ActivityModel Activity { get; set; }

        public IList<StudentActivityModel> StudentActivities { get; set; }
    }
}
