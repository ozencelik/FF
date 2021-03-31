using FF.Data.Entities.Schools;
using FF.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Core.Services.Schools
{
    public class SchoolService : ISchoolService
    {
        #region Fields
        private readonly IRepository<School> _schoolRepository;
        #endregion

        #region Ctor
        public SchoolService(IRepository<School> schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        #endregion

        #region Methods
        public async Task<IList<School>> GetAllSchoolsAsync()
        {
            return await _schoolRepository.Table
                .Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<School> GetSchoolByIdAsync(int schoolId)
        {
            return await _schoolRepository.Table
                .FirstOrDefaultAsync(x => x.Id == schoolId
                && !x.Deleted);
        }

        public async Task<int> InsertSchoolAsync(School school)
        {
            return await _schoolRepository.InsertAsync(school);
        }

        public async Task<int> UpdateSchoolAsync(School school)
        {
            return await _schoolRepository.UpdateAsync(school);
        }

        public async Task<int> DeleteSchoolAsync(School school)
        {
            school.Deleted = true;
            return await _schoolRepository.UpdateAsync(school);
        }
        #endregion
    }
}
