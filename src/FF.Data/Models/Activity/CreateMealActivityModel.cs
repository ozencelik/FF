using FF.Data.Enums.MealAmounts;

namespace FF.Data.Models.Activity
{
    public class CreateMealActivityModel
    {
        public int StudentId { get; set; }
        
        public string Description { get; set; }

        public MealAmount MealAmount { get; set; }
    }
}
