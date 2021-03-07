using FF.Data.Entities.Base;
using FF.Data.Entities.Schools;
using FF.Data.Entities.Teachers;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Entities.Classes
{
    public class Class : BaseEntity
    {
        /// <summary>
        /// Class name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Class's school
        /// </summary>
        [ForeignKey("SchoolId")]
        public School School { get; set; }

        /// <summary>
        /// Class's teacher
        /// </summary>
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
    }
}
