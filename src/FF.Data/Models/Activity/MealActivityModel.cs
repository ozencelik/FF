using FF.Data.Entities.Students;
using FF.Data.Enums.MealAmounts;
using System.Collections.Generic;

namespace FF.Data.Models.Activity
{
    public class MealActivityModel
    {
        public IList<Student> Students { get; set; }

        public IList<MealAmount> MealAmounts { get; set; }

        public IList<CreateMealActivityModel> Activities { get; set; }
    }
}
