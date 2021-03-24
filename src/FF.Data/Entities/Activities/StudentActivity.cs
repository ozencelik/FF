using FF.Data.Entities.Base;
using FF.Data.Entities.Students;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Entities.Activities
{
    public class StudentActivity : BaseEntity
    {
        /// <summary>
        /// ActivityDescription
        /// </summary>
        public string Description { get; set; }

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
        /// Student Activities' activity option id
        /// </summary>
        public int ActivityOptionId { get; set; }

        /// <summary>
        /// Student's activity option
        /// </summary>
        [ForeignKey("ActivityOptionId")]
        public ActivityOption ActivityOption { get; set; }

        /// <summary>
        /// Student Activities' student id
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Student's activity
        /// </summary>
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
