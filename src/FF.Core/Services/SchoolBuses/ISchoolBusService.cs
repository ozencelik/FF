using FF.Data.Entities.SchoolBuses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FF.Core.Services.SchoolBuses
{
    public interface ISchoolBusService
    {
        /// <summary>
        /// Gets all school buses
        /// </summary>
        /// <returns>SchoolBuses</returns>
        Task<IList<SchoolBus>> GetAllSchoolBusesAsync();

        /// <summary>
        /// Gets a school bus
        /// </summary>
        /// <param name="schoolBusId">SchoolBus identifier</param>
        /// <returns>SchoolBus</returns>
        Task<SchoolBus> GetSchoolBusByIdAsync(int schoolBusId);

        /// <summary>
        /// Gets a school bus
        /// </summary>
        /// <param name="accessCode">SchoolBus access code</param>
        /// <returns>SchoolBus</returns>
        Task<SchoolBus> GetSchoolBusByAccessCodeAsync(string accessCode);

        /// <summary>
        /// Insert the school bus
        /// </summary>
        /// <returns>SchoolBus Id</returns>
        Task<int> InsertSchoolBusAsync(SchoolBus schoolBus);

        /// <summary>
        /// Updates the school bus
        /// </summary>
        /// <returns>SchoolBus Id</returns>
        Task<int> UpdateSchoolBusAsync(SchoolBus schoolBus);

        /// <summary>
        /// Deletes the school bus
        /// </summary>
        /// <returns>SchoolBus Id</returns>
        Task<int> DeleteSchoolBusAsync(SchoolBus schoolBus);
    }
}
