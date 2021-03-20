using FF.Data.Entities.StudentActivities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FF.Core.Services.Activities
{
    public interface IMealActivityService
    {
        /// <summary>
        /// Gets all meal activites
        /// </summary>
        /// <returns>MealActivities</returns>
        Task<IList<Meal>> GetAllMealActivitiesAsync();

        /// <summary>
        /// Gets a meal activity
        /// </summary>
        /// <param name="studentId">Meal Activity identifier</param>
        /// <returns>Meal Activity</returns>
        Task<Meal> GetMealActivityByIdAsync(int mealActivityId);

        /// <summary>
        /// Insert the meal activity
        /// </summary>
        /// <returns>Meal Acitivity Id</returns>
        Task<int> InsertMealActivityAsync(Meal mealActivity);

        /// <summary>
        /// Updates the meal activity
        /// </summary>
        /// <returns>Meal Activity Id</returns>
        Task<int> UpdateMealActivityAsync(Meal mealActivity);
    }
}
