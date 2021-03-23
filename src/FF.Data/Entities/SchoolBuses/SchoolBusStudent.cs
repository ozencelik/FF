using FF.Data.Entities.Base;
using FF.Data.Entities.Students;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Entities.SchoolBuses
{
    public class SchoolBusStudent : BaseEntity
    {
        /// <summary>
        /// School bus identifier
        /// </summary>
        public int SchoolBusId { get; set; }

        /// <summary>
        /// SchoolBusStudent's schoolbus
        /// </summary>
        [ForeignKey("SchoolBusId")]
        public SchoolBus SchoolBus { get; set; }

        /// <summary>
        /// Student identifier
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// SchoolBusStudent's student
        /// </summary>
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
