using FF.Data.Entities.Base;
using FF.Data.Entities.Classes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Entities.Teachers
{
    public class Teacher : Person
    {
        /// <summary>
        /// Teacher's class
        /// </summary>
        public ICollection<Class> Classes { get; set; }
    }
}
