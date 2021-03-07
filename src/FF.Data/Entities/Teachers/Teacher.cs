using FF.Data.Entities.Base;

namespace FF.Data.Entities.Teachers
{
    public class Teacher : Person
    {
        /// <summary>
        /// Student's school
        /// </summary>
        [ForeignKey("SchoolId")]
        public School School { get; set; }
    }
}
