using FF.Data.Entities.Activities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FF.Core.Services.Activities
{
    public interface IStudentActivityService
    {
        /// <summary>
        /// Gets all activites
        /// </summary>
        /// <returns>StudentActivities</returns>
        Task<IList<StudentActivity>> GetAllStudentActivitiesAsync();

        /// <summary>
        /// Gets a studentActivity
        /// </summary>
        /// <param name="studentActivityId">StudentActivity identifier</param>
        /// <returns> StudentActivity</returns>
        Task<StudentActivity> GetStudentActivityByIdAsync(int studentActivityId);

        /// <summary>
        /// Insert the studentActivity
        /// </summary>
        /// <returns> Acitivity Id</returns>
        Task<int> InsertStudentActivityAsync(StudentActivity studentActivity);

        /// <summary>
        /// Updates the studentActivity
        /// </summary>
        /// <returns> StudentActivity Id</returns>
        Task<int> UpdateStudentActivityAsync(StudentActivity studentActivity);
    }
}
