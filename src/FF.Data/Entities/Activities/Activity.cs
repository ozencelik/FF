using FF.Data.Entities.Base;
using System.Collections.Generic;

namespace FF.Data.Entities.Activities
{
    public class Activity : BaseEntity
    {
        /// <summary>
        /// Activity Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Activity's studentActivitiesOptions
        /// </summary>
        public IList<ActivityOption> ActivityOptions { get; set; }

        /// <summary>
        /// Activity's studentActivities
        /// </summary>
        public IList<StudentActivity> StudentActivities { get; set; }
    }
}
