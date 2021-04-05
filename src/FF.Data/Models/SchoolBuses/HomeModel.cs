using FF.Data.Models.Activities;
using System.Collections.Generic;

namespace FF.Data.Models.SchoolBuses
{
    public class HomeModel
    {
        public SchoolBusModel SchoolBus { get; set; }

        public IList<ActivityModel> Activities { get; set; }
    }
}
