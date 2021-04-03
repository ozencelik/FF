using System;

namespace FF.Data.Models.Base
{
    public class PersonModel : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTime Birthday { get; set; }
    }
}
