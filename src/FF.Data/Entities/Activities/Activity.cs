using FF.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public ICollection<ActivityOption> ActivityOptions { get; set; }

        /// <summary>
        /// Activity's studentActivities
        /// </summary>
        public ICollection<StudentActivity> StudentActivities { get; set; }
    }
}
