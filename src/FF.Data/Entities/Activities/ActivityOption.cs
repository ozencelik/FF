using FF.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FF.Data.Entities.Activities
{
    public class ActivityOption : BaseEntity
    {
        /// <summary>
        /// Activity optionName
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Student Activities' activity id
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Student's activity
        /// </summary>
        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }
    }
}
