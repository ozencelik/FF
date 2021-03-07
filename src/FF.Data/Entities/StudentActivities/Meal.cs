using FF.Data.Enums.MealAmounts;

namespace FF.Data.Entities.StudentActivities
{
    public class Meal : StudentActivity
    {
        /// <summary>
        /// How much a child ate his/her food
        /// </summary>
        public MealAmount MealAmount { get; set; } = MealAmount.NeverEaten;
    }
}
