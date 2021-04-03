using System;
using System.Collections.Generic;
using System.Text;

namespace FF.Data.Models.Teachers
{
    public class TeacherModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int ClassId { get; set; }

    }
}
