using FF.Data.Entities.Schools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FF.Core.Services.Schools
{
    public interface ISchoolService
    {
        /// <summary>
        /// Gets all schools
        /// </summary>
        /// <returns>Schools</returns>
        Task<IList<School>> GetAllSchoolsAsync();

        /// <summary>
        /// Gets a school
        /// </summary>
        /// <param name="schoolId">School identifier</param>
        /// <returns>School</returns>
        Task<School> GetSchoolByIdAsync(int schoolId);

        /// <summary>
        /// Insert the school
        /// </summary>
        /// <returns>School Id</returns>
        Task<int> InsertSchoolAsync(School school);

        /// <summary>
        /// Updates the school
        /// </summary>
        /// <returns>School Id</returns>
        Task<int> UpdateSchoolAsync(School school);

        /// <summary>
        /// Deletes the school
        /// </summary>
        /// <returns>School Id</returns>
        Task<int> DeleteSchoolAsync(School school);
    }
}
