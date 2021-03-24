using System;

namespace FF.Data.Models.Students
{
    public class StudentModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTime Birthday { get; set; }

        public int ClassId { get; set; }

        public int ParentId { get; set; }

        public int SchoolId { get; set; }
    }
}
