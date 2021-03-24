using FF.Data.Entities.Activities;
using FF.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Core.Services.Activities
{
    public class StudentActivityService : IStudentActivityService
    {
        #region Fields
        private readonly IRepository<StudentActivity> _studentActivityRepository;
        #endregion

        #region Ctor
        public StudentActivityService(IRepository<StudentActivity> studentActivityRepository)
        {
            _studentActivityRepository = studentActivityRepository;
        }
        #endregion

        #region Methods
        public async Task<IList<StudentActivity>> GetAllStudentActivitiesAsync()
        {
            return await _studentActivityRepository
                .Table
                .Where(x => !x.Deleted)
                .ToListAsync();
        }

        public async Task<StudentActivity> GetStudentActivityByIdAsync(int studentActivityId)
        {
            return await _studentActivityRepository
                .Table
                .FirstOrDefaultAsync(x => x.Id == studentActivityId
                && !x.Deleted);
        }

        public async Task<int> InsertStudentActivityAsync(StudentActivity studentAcitivty)
        {
            return await _studentActivityRepository.InsertAsync(studentAcitivty);
        }

        public async Task<int> UpdateStudentActivityAsync(StudentActivity studentActivity)
        {
            return await _studentActivityRepository.UpdateAsync(studentActivity);
        }
        #endregion
    }
}
