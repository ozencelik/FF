using FF.Data.Entities.Activities;
using FF.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Entities.Actions
{
    public class Action : BaseEntity
    {
        /// <summary>
        /// Student Activities' activity id
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Student's activity
        /// </summary>
        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }

        /// <summary>
        /// Activity's studentActivities
        /// </summary>
        public ICollection<StudentActivity> StudentActivities { get; set; }
    }
}
