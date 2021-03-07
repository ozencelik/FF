﻿using FF.Data.Entities.Base;
using FF.Data.Entities.Schools;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Entities.SchoolBusAttendants
{
    public class SchoolBusAttendant : Person
    {
        /// <summary>
        /// Class's school id
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// SchoolBusAttendant's school
        /// </summary>
        [ForeignKey("SchoolId")]
        public School School { get; set; }
    }
}
