using FF.Data.Entities.Base;
using FF.Data.Entities.Classes;
using FF.Data.Entities.Schools;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Entities.Teachers
{
    public class Teacher : Person
    {
        /// <summary>
        /// Teacher's school id
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// Teacher's school
        /// </summary>
        [ForeignKey("SchoolId")]
        public School School { get; set; }

        /// <summary>
        /// Teacher's class
        /// </summary>
        public IList<Class> Classes { get; set; }
    }
}
