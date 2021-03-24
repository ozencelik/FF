using FF.Data.Entities.Actions;
using FF.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Core.Services.Actions
{
    public class ActionService : IActionService
    {
        #region Fields
        private readonly IRepository<Action> _actionRepository;
        #endregion

        #region Ctor
        public ActionService(IRepository<Action> actionRepository)
        {
            _actionRepository = actionRepository;
        }
        #endregion

        #region Methods
        public async Task<IList<Action>> GetAllActionsAsync()
        {
            return await _actionRepository
                .Table
                .Where(x => !x.Deleted)
                .ToListAsync();
        }

        public async Task<Action> GetActionByIdAsync(int actionId)
        {
            return await _actionRepository
                .Table
                .FirstOrDefaultAsync(x => x.Id == actionId && !x.Deleted);
        }

        public async Task<int> InsertActionAsync(Action mealAcitivty)
        {
            return await _actionRepository.InsertAsync(mealAcitivty);
        }

        public async Task<int> UpdateActionAsync(Action action)
        {
            return await _actionRepository.UpdateAsync(action);
        }
        #endregion
    }
}
