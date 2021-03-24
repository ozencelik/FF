using FF.Data.Models.Actions;
using FF.Data.Models.Students;
using System.Collections.Generic;

namespace FF.Data.Models.Activities
{
    public class ActivityModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<ActivityOptionModel> ActivityOptions { get; set; }

        public IList<ActionModel> Actions { get; set; }

        public IList<StudentModel> Students { get; set; }
    }
}
