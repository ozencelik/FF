using FF.Data.Entities.Base;
using FF.Data.Entities.Schools;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Entities.SchoolBuses
{
    public class SchoolBus : Person
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

        /// <summary>
        /// SchoolBus car plate
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// SchoolBus attendant phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// SchoolBus company name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// SchoolBues's students
        /// </summary>
        public IList<SchoolBusStudent> SchoolBusStudents { get; set; }
    }
}
