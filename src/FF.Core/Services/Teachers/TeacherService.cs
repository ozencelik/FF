﻿using FF.Data.Entities.Teachers;
using FF.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Core.Services.Teachers
{
    public class TeacherService : ITeacherService
    {
        #region Fields
        private readonly IRepository<Teacher> _teacherRepository;
        #endregion

        #region Ctor
        public TeacherService(IRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        #endregion

        #region Methods
        public async Task<int> GetTeachersCount()
        {
            // TO DO : Date filter can be added.
            return await _teacherRepository
                .Table
                .Where(x => !x.Deleted)
                .CountAsync();
        }

        public async Task<IList<Teacher>> GetAllTeachersAsync()
        {
            return await _teacherRepository.Table
                .Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<Teacher> GetTeacherByIdAsync(int teacherId)
        {
            return await _teacherRepository.Table
                .Include(t => t.Classes)
                .FirstOrDefaultAsync(x => x.Id == teacherId
                && !x.Deleted);
        }

        public async Task<Teacher> GetTeacherByAccessCodeAsync(string accessCode)
        {
            return await _teacherRepository.Table
                .FirstOrDefaultAsync(x => x.ProfileAccessCode.Equals(accessCode)
                && !x.Deleted);
        }

        public async Task<int> InsertTeacherAsync(Teacher teacher)
        {
            teacher.ProfileAccessCode = Guid.NewGuid().ToString();
            return await _teacherRepository.InsertAsync(teacher);
        }

        public async Task<int> UpdateTeacherAsync(Teacher teacher)
        {
            return await _teacherRepository.UpdateAsync(teacher);
        }

        public async Task<int> DeleteTeacherAsync(Teacher teacher)
        {
            teacher.Deleted = true;
            return await _teacherRepository.UpdateAsync(teacher);
        }
        #endregion
    }
}
