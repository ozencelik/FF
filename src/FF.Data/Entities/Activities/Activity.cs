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
        [NotMapped]
        public IList<ActivityOption> ActivityOptions { get; set; }

        /// <summary>
        /// Activity's studentActivities
        /// </summary>
        [NotMapped]
        public IList<StudentActivity> StudentActivities { get; set; }
    }
}
