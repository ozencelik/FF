using FF.Data.Models.StudentModels;
using System.Collections.Generic;

namespace FF.Data.Models.Activity
{
    public class ActivityModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<ActivityOptionModel> ActivityOptions { get; set; }

        public IList<StudentActivityModel> StudentActivities { get; set; }

        public IList<StudentModel> Students { get; set; }
    }
}
