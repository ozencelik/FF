using FF.Data.Enums.ServiceMovementTypes;

namespace FF.Data.Entities.StudentActivities
{
    public class Service : StudentActivity
    {
        /// <summary>
        /// Service Movement Type
        /// </summary>
        public ServiceMovementType ServiceMovementType { get; set; } = ServiceMovementType.DidntGetOn;
    }
}
