using FF.Data.Enums.MealAmounts;

namespace FF.Web.Models.Activity
{
    public class CreateMealActivityModel
    {
        public int Id { get; set; }

        public MealAmount MealAmount { get; set; }
    }
}
