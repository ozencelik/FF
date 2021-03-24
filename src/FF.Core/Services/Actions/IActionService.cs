using FF.Data.Entities.Actions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FF.Core.Services.Actions
{
    public interface IActionService
    {
        /// <summary>
        /// Gets all activites
        /// </summary>
        /// <returns>Actions</returns>
        Task<IList<Action>> GetAllActionsAsync();

        /// <summary>
        /// Gets an action
        /// </summary>
        /// <param name="actionId">Action identifier</param>
        /// <returns> Action</returns>
        Task<Action> GetActionByIdAsync(int actionId);

        /// <summary>
        /// Insert the action
        /// </summary>
        /// <returns> Action Id</returns>
        Task<int> InsertActionAsync(Action action);

        /// <summary>
        /// Updates the action
        /// </summary>
        /// <returns> Action Id</returns>
        Task<int> UpdateActionAsync(Action action);
    }
}
