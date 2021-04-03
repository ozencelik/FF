using FF.Data.Models.Base;
using FF.Data.Models.Classes;
using System.Collections.Generic;

namespace FF.Data.Models.Teachers
{
    public class UpdateTeacherModel : PersonModel
    {
        public IList<ClassModel> Classes { get; set; }
    }
}
