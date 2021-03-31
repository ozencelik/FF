using FF.Data.Entities.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FF.Core.Services.Classes
{
    public interface IClassService
    {
        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>Classes</returns>
        Task<IList<Class>> GetAllClasssAsync();

        /// <summary>
        /// Gets a class
        /// </summary>
        /// <param name="studentId">Class identifier</param>
        /// <returns>Class</returns>
        Task<Class> GetClassByIdAsync(int studentId);

        /// <summary>
        /// Insert the class
        /// </summary>
        /// <returns>Class Id</returns>
        Task<int> InsertClassAsync(Class classModel);

        /// <summary>
        /// Updates the class
        /// </summary>
        /// <returns>Class Id</returns>
        Task<int> UpdateClassAsync(Class classModel);

        /// <summary>
        /// Deletes the class
        /// </summary>
        /// <returns>Class Id</returns>
        Task<int> DeleteClassAsync(Class classModel);
    }
}
