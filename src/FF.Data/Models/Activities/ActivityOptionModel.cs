namespace FF.Data.Models.Activities
{
    public class ActivityOptionModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ActivityId { get; set; }

        public ActivityModel Activity { get; set; }
    }
}
