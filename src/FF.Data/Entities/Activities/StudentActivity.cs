using FF.Data.Entities.Actions;
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
        /// Student Activities' action id
        /// </summary>
        public int ActionId { get; set; }

        /// <summary>
        /// Student's action
        /// </summary>
        [ForeignKey("ActionId")]
        public Action Action { get; set; }

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
