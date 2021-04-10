using FF.Data.Entities.SchoolBuses;
using FF.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Core.Services.SchoolBuses
{
    public class SchoolBusService : ISchoolBusService
    {
        #region Fields
        private readonly IRepository<SchoolBus> _schoolRepository;
        #endregion

        #region Ctor
        public SchoolBusService(IRepository<SchoolBus> schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        #endregion

        #region Methods
        public async Task<IList<SchoolBus>> GetAllSchoolBusesAsync()
        {
            return await _schoolRepository.Table
                .Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<SchoolBus> GetSchoolBusByIdAsync(int schoolId)
        {
            return await _schoolRepository.Table
                .FirstOrDefaultAsync(x => x.Id == schoolId
                && !x.Deleted);
        }

        public async Task<SchoolBus> GetSchoolBusByAccessCodeAsync(string accessCode)
        {
            return await _schoolRepository.Table
                .FirstOrDefaultAsync(x => x.ProfileAccessCode.Equals(accessCode)
                && !x.Deleted);
        }

        public async Task<int> InsertSchoolBusAsync(SchoolBus school)
        {
            school.ProfileAccessCode = Guid.NewGuid().ToString();
            return await _schoolRepository.InsertAsync(school);
        }

        public async Task<int> UpdateSchoolBusAsync(SchoolBus school)
        {
            return await _schoolRepository.UpdateAsync(school);
        }

        public async Task<int> DeleteSchoolBusAsync(SchoolBus school)
        {
            school.Deleted = true;
            return await _schoolRepository.UpdateAsync(school);
        }
        #endregion
    }
}
