using FF.Data.Entities.Classes;
using FF.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Core.Services.Classes
{
    public class ClassService : IClassService
    {
        #region Fields
        private readonly IRepository<Class> _classRepository;
        #endregion

        #region Ctor
        public ClassService(IRepository<Class> classRepository)
        {
            _classRepository = classRepository;
        }
        #endregion

        #region Methods
        public async Task<IList<Class>> GetAllClassesAsync()
        {
            return await _classRepository.Table
                .Include(c => c.Teacher)
                .Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<Class> GetClassByIdAsync(int classId)
        {
            return await _classRepository.Table
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(x => x.Id == classId
                && !x.Deleted);
        }

        public async Task<int> InsertClassAsync(Class classModel)
        {
            return await _classRepository.InsertAsync(classModel);
        }

        public async Task<int> UpdateClassAsync(Class classModel)
        {
            return await _classRepository.UpdateAsync(classModel);
        }

        public async Task<int> DeleteClassAsync(Class classModel)
        {
            classModel.Deleted = true;
            return await _classRepository.UpdateAsync(classModel);
        }
        #endregion
    }
}
