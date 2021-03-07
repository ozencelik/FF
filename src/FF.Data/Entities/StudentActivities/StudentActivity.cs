using FF.Data.Entities.Base;
using FF.Data.Entities.Students;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Entities.StudentActivities
{
    public class StudentActivity : BaseEntity
    {
        /// <summary>
        /// ActivityDescription
        /// </summary>
        public string Description { get; set; }

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
