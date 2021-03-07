using FF.Data.Entities.Base;
using FF.Data.Entities.Classes;
using FF.Data.Entities.Parents;
using FF.Data.Entities.Schools;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Entities.Students
{
    public class Student : Person
    {
        /// <summary>
        /// Student's class id
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// Student's class
        /// </summary>
        [ForeignKey("ClassId")]
        public Class Class { get; set; }

        /// <summary>
        /// Student's parent id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Student's parent
        /// </summary>
        [ForeignKey("ParentId")]
        public Parent Parent { get; set; }

        /// <summary>
        /// Student's school id
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// Student's school
        /// </summary>
        [ForeignKey("SchoolId")]
        public School School { get; set; }
    }
}
