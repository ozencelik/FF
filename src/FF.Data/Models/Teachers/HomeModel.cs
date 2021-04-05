using FF.Data.Models.Activities;
using FF.Data.Models.Classes;
using System.Collections.Generic;

namespace FF.Data.Models.Teachers
{
    public class HomeModel
    {
        public TeacherModel Teacher { get; set; }

        public IList<ActivityModel> Activities { get; set; }
    }
}
