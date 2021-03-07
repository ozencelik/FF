using FF.Data.Entities.Base;
using FF.Data.Entities.Students;
using System.Collections.Generic;

namespace FF.Data.Entities.Parents
{
    public class Parent : Person
    {
        /// <summary>
        /// Parent's children
        /// </summary>
        public IList<Student> Students { get; set; }
    }
}
