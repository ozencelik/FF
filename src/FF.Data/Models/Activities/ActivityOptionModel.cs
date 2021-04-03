using FF.Data.Models.Base;

namespace FF.Data.Models.Activities
{
    public class ActivityOptionModel : BaseModel
    {
        public string Name { get; set; }

        public int ActivityId { get; set; }

        public ActivityModel Activity { get; set; }
    }
}
