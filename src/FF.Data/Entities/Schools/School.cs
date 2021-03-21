using FF.Data.Entities.Base;
using FF.Data.Entities.Classes;
using FF.Data.Entities.SchoolBusAttendants;
using FF.Data.Entities.Students;
using FF.Data.Entities.Teachers;
using System.Collections.Generic;

namespace FF.Data.Entities.Schools
{
    public class School : BaseEntity
    {
        /// <summary>
        /// School name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// School's class
        /// </summary>
        public IList<Class> Classes { get; set; }

        /// <summary>
        /// School's schoolBusAttendant
        /// </summary>
        public IList<SchoolBusAttendant> SchoolBusAttendants { get; set; }

        /// <summary>
        /// School's teacher
        /// </summary>
        public IList<Teacher> Teachers { get; set; }
    }
}
