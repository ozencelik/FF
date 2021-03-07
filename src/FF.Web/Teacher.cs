using FF.Data.Entities.Base;
using FF.Data.Entities.Schools;
using System.ComponentModel.DataAnnotations.Schema;

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
