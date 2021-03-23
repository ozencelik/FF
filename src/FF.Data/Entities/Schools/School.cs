using FF.Data.Entities.Base;
using FF.Data.Entities.Classes;
using FF.Data.Entities.SchoolBuses;
using FF.Data.Entities.Teachers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public IList<Class> Classes { get; set; }

        /// <summary>
        /// School's schoolBusAttendant
        /// </summary>
        [NotMapped]
        public IList<SchoolBus> SchoolBuses { get; set; }

        /// <summary>
        /// School's teacher
        /// </summary>
        [NotMapped]
        public IList<Teacher> Teachers { get; set; }
    }
}
