using FF.Data.Entities.Students;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FF.Core.Services.Students
{
    public interface IStudentService
    {
        /// <summary>
        /// Gets all categories
        /// </summary>
        /// <returns>Students</returns>
        Task<IList<Student>> GetAllStudentsAsync();

        /// <summary>
        /// Gets a student
        /// </summary>
        /// <param name="studentId">Student identifier</param>
        /// <returns>Student</returns>
        Task<Student> GetStudentByIdAsync(int studentId);

        /// <summary>
        /// Gets a student
        /// </summary>
        /// <param name="code">Student profile access code</param>
        /// <returns>Student</returns>
        Task<Student> GetStudentByProfileAccessCodeAsync(string code);

        /// <summary>
        /// Insert the student
        /// </summary>
        /// <returns>Student Id</returns>
        Task<int> InsertStudentAsync(Student student);

        /// <summary>
        /// Updates the student
        /// </summary>
        /// <returns>Student Id</returns>
        Task<int> UpdateStudentAsync(Student student);

        /// <summary>
        /// Deletes the student
        /// </summary>
        /// <returns>Student Id</returns>
        Task<int> DeleteStudentAsync(Student student);
    }
}
