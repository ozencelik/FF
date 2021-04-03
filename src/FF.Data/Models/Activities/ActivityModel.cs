using FF.Data.Models.Actions;
using FF.Data.Models.Base;
using FF.Data.Models.Students;
using System.Collections.Generic;

namespace FF.Data.Models.Activities
{
    public class ActivityModel : BaseModel
    {
        public string Name { get; set; }

        public IList<ActivityOptionModel> ActivityOptions { get; set; }

        public IList<ActionModel> Actions { get; set; }

        public IList<StudentModel> Students { get; set; }
    }
}
