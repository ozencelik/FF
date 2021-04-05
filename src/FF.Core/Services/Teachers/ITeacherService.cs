using FF.Data.Entities.Teachers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FF.Core.Services.Teachers
{
    public interface ITeacherService
    {
        /// <summary>
        /// Gets all teachers
        /// </summary>
        /// <returns>Teachers</returns>
        Task<IList<Teacher>> GetAllTeachersAsync();

        /// <summary>
        /// Gets a teacher
        /// </summary>
        /// <param name="teacherId">Teacher identifier</param>
        /// <returns>Teacher</returns>
        Task<Teacher> GetTeacherByIdAsync(int teacherId);

        /// <summary>
        /// Gets a teacher
        /// </summary>
        /// <param name="accessCode">Teacher access code</param>
        /// <returns>Teacher</returns>
        Task<Teacher> GetTeacherByAccessCodeAsync(string accessCode);

        /// <summary>
        /// Insert the teacher
        /// </summary>
        /// <returns>Teacher Id</returns>
        Task<int> InsertTeacherAsync(Teacher teacher);

        /// <summary>
        /// Updates the teacher
        /// </summary>
        /// <returns>Teacher Id</returns>
        Task<int> UpdateTeacherAsync(Teacher teacher);

        /// <summary>
        /// Deletes the teacher
        /// </summary>
        /// <returns>Teacher Id</returns>
        Task<int> DeleteTeacherAsync(Teacher teacher);
    }
}
