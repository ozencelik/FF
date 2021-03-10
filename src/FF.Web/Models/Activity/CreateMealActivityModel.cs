using FF.Data.Entities.Students;
using FF.Data.Enums.MealAmounts;

namespace FF.Web.Models.Activity
{
    public class CreateMealActivityModel
    {
        public Student Student { get; set; }

        public MealAmount MealAmount { get; set; }
    }
}
