using FF.Data.Entities.Activities;
using FF.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Core.Services.Activities
{
    public class ActivityService : IActivityService
    {
        #region Fields
        private readonly IRepository<Activity> _activityRepository;
        #endregion

        #region Ctor
        public ActivityService(IRepository<Activity> activityRepository)
        {
            _activityRepository = activityRepository;
        }
        #endregion

        #region Methods
        public async Task<IList<Activity>> GetAllActivitiesAsync()
        {
            return await _activityRepository
                .Table
                .Where(x => !x.Deleted)
                .ToListAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(int activityId)
        {
            return await _activityRepository
                .Table
                .Include(a => a.ActivityOptions)
                .FirstOrDefaultAsync(x => x.Id == activityId && !x.Deleted);
        }

        public async Task<int> InsertActivityAsync(Activity mealAcitivty)
        {
            return await _activityRepository.InsertAsync(mealAcitivty);
        }

        public async Task<int> UpdateActivityAsync(Activity activity)
        {
            return await _activityRepository.UpdateAsync(activity);
        }
        #endregion
    }
}
