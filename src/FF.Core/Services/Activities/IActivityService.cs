using FF.Data.Entities.Activities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FF.Core.Services.Activities
{
    public interface IActivityService
    {
        /// <summary>
        /// Gets all activites
        /// </summary>
        /// <returns>Activities</returns>
        Task<IList<Activity>> GetAllActivitiesAsync();

        /// <summary>
        /// Gets teacher activites
        /// </summary>
        /// <returns>Activities</returns>
        Task<IList<Activity>> GetTeacherActivitiesAsync();

        /// <summary>
        /// Gets schoolBus activites
        /// </summary>
        /// <returns>Activities</returns>
        Task<IList<Activity>> GetSchoolBusActivitiesAsync();

        /// <summary>
        /// Gets an activity
        /// </summary>
        /// <param name="activityId">Activity identifier</param>
        /// <returns> Activity</returns>
        Task<Activity> GetActivityByIdAsync(int activityId);

        /// <summary>
        /// Insert the activity
        /// </summary>
        /// <returns> Acitivity Id</returns>
        Task<int> InsertActivityAsync(Activity activity);

        /// <summary>
        /// Updates the activity
        /// </summary>
        /// <returns> Activity Id</returns>
        Task<int> UpdateActivityAsync(Activity activity);
    }
}
