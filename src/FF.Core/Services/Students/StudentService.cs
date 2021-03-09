﻿using FF.Data.Entities.Students;
using FF.Data.Repositories;
using Microsoft.EntityFrameworkCore;
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
                .Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _studentRepository.Table
                .FirstOrDefaultAsync(x => x.Id == studentId
                && !x.Deleted);
        }

        public async Task<int> InsertStudentAsync(Student student)
        {
            return await _studentRepository.InsertAsync(student);
        }

        public async Task<int> UpdateStudentAsync(Student student)
        {
            return await _studentRepository.UpdateAsync(student);
        }
        #endregion
    }
}