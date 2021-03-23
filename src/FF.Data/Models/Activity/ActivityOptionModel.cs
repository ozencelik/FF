namespace FF.Data.Models.Activity
{
    public class ActivityOptionModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ActivityId { get; set; }

        public ActivityModel Activity { get; set; }
    }
}
