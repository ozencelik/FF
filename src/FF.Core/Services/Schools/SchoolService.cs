using FF.Core.Services.Activities;
using FF.Core.Services.Classes;
using FF.Core.Services.SchoolBuses;
using FF.Core.Services.Students;
using FF.Core.Services.Teachers;
using FF.Data.Entities.Schools;
using FF.Data.Models.Schools;
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
        private readonly IActivityService _activityService;
        private readonly IClassService _classService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly ISchoolBusService _schoolBusService;
        #endregion

        #region Ctor
        public SchoolService(IRepository<School> schoolRepository,
            IActivityService activityService,
            IClassService classService,
            ITeacherService teacherService,
            IStudentService studentService,
            ISchoolBusService schoolBusService)
        {
            _schoolRepository = schoolRepository;
            _activityService = activityService;
            _classService = classService;
            _teacherService = teacherService;
            _studentService = studentService;
            _schoolBusService = schoolBusService;
        }
        #endregion

        #region Methods
        public async Task<IList<School>> GetAllSchoolsAsync()
        {
            return await _schoolRepository.Table
                .Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<DashboardModel> GetDashboardCardsCount()
        {
            return new DashboardModel()
            {
                ActivitiesCount = await _activityService.GetActiviesCount(),
                ClassesCount = await _classService.GetClassesCount(),
                TeachersCount = await _teacherService.GetTeachersCount(),
                StudentsCount = await _studentService.GetStudentsCount(),
                SchoolBusesCount = await _schoolBusService.GetSchoolBusesCount()
            };
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
