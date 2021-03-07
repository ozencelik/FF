using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Entities.Base
{
    public class Person : BaseEntity
    {
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Full name.
        /// </summary>
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Birthday.
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
