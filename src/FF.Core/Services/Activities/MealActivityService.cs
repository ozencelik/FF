using FF.Data.Entities.StudentActivities;
using FF.Data.Entities.Students;
using FF.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Core.Services.Activities
{
    public class MealActivityService : IMealActivityService
    {
        #region Fields
        private readonly IRepository<Meal> _mealRepository;
        #endregion

        #region Ctor
        public MealActivityService(IRepository<Meal> mealRepository)
        {
            _mealRepository = mealRepository;
        }
        #endregion

        #region Methods
        public async Task<IList<Meal>> GetAllMealActivitiesAsync()
        {
            return await _mealRepository.Table
                .Include(s => s.Student)
                .Where(x => !x.Deleted).ToListAsync();
        }

        public async Task<Meal> GetMealActivityByIdAsync(int mealActivityId)
        {
            return await _mealRepository.Table
                .FirstOrDefaultAsync(x => x.Id == mealActivityId
                && !x.Deleted);
        }

        public async Task<int> InsertMealActivityAsync(Meal mealAcitivty)
        {
            return await _mealRepository.InsertAsync(mealAcitivty);
        }

        public async Task<int> UpdateMealActivityAsync(Meal mealActivity)
        {
            return await _mealRepository.UpdateAsync(mealActivity);
        }
        #endregion
    }
}
