using FF.Data.Entities.Students;
using FF.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Core.Services.Students
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IRepository<Student> _studentRepository;
        #endregion

        #region Ctor
        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        #endregion

        #region Methods
        public async Task<IList<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.Table
                .Include(s => s.Class)
                .Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _studentRepository.Table
                .FirstOrDefaultAsync(x => x.Id == studentId
                && !x.Deleted);
        }

        public async Task<Student> GetStudentByProfileAccessCodeAsync(string code)
        {
            return await _studentRepository.Table
                .FirstOrDefaultAsync(x => x.ProfileAccessCode.Equals(code)
                && !x.Deleted);
        }

        public async Task<int> InsertStudentAsync(Student student)
        {
            student.ProfileAccessCode = Guid.NewGuid().ToString();
            return await _studentRepository.InsertAsync(student);
        }

        public async Task<int> UpdateStudentAsync(Student student)
        {
            return await _studentRepository.UpdateAsync(student);
        }

        public async Task<int> DeleteStudentAsync(Student student)
        {
            student.Deleted = true;
            return await _studentRepository.UpdateAsync(student);
        }
        #endregion
    }
}
