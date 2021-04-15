using FF.Data.Entities.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FF.Core.Services.Classes
{
    public interface IClassService
    {
        /// <summary>
        /// Gets all classes
        /// </summary>
        /// <returns>Classes</returns>
        Task<IList<Class>> GetAllClassesAsync();

        /// <summary>
        /// Gets a class
        /// </summary>
        /// <param name="classId">Class identifier</param>
        /// <returns>Class</returns>
        Task<Class> GetClassByIdAsync(int classId);

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
