using FF.Data.Entities.Activities;
using FF.Data.Entities.Base;
using FF.Data.Entities.Classes;
using FF.Data.Entities.SchoolBuses;
using System;
using System.Collections.Generic;
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
        /// Student's schoolBus id
        /// </summary>
        public int SchoolBusId { get; set; }

        /// <summary>
        /// Student's schoolBus
        /// </summary>
        [ForeignKey("SchoolBusId")]
        public SchoolBus SchoolBus { get; set; }

        /// <summary>
        /// Student's parent first name
        /// </summary>
        public string ParentFirstName { get; set; }

        /// <summary>
        /// Student's parent last name
        /// </summary>
        public string ParentLastName { get; set; }

        /// <summary>
        /// Student's parent phone number
        /// </summary>
        public string ParentPhoneNumber { get; set; }

        /// <summary>
        /// Student's parent email
        /// </summary>
        public string ParentEmail { get; set; }

        /// <summary>
        /// Activity's studentActivities
        /// </summary>
        public ICollection<StudentActivity> StudentActivities { get; set; }
    }
}
