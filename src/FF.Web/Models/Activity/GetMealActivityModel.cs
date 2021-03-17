using FF.Data.Entities.Students;
using FF.Data.Enums.MealAmounts;
using System.Collections.Generic;

namespace FF.Web.Models.Activity
{
    public class GetMealActivityModel
    {
        public IList<Student> Students { get; set; }

        public IList<MealAmount> MealAmounts { get; set; }
    }
}
