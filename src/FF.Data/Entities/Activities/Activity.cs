using FF.Data.Entities.Actions;
using FF.Data.Entities.Base;
using System.Collections.Generic;

namespace FF.Data.Entities.Activities
{
    public class Activity : BaseEntity
    {
        /// <summary>
        /// Activity Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Activity icon class
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Activity's studentActivitiesOptions
        /// </summary>
        public ICollection<ActivityOption> ActivityOptions { get; set; }

        /// <summary>
        /// Activity's studentActivities
        /// </summary>
        public ICollection<Action> Actions { get; set; }
    }
}
