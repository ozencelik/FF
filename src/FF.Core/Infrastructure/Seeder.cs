using FF.Data.Context.MySql;
using FF.Data.Entities.Classes;
using FF.Data.Entities.Parents;
using FF.Data.Entities.Schools;
using FF.Data.Entities.Students;
using FF.Data.Entities.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FF.Core.Infrastructure
{
    public static class Seeder
    {
        #region Methods
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Look for any Book.
                if (dbContext.Student.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateData(dbContext);
            }
        }

        public static void PopulateData(AppDbContext dbContext)
        {
            #region Create School
            var school = new School
            {
                Name = "Konyanın En Güzel Okulu"
            };

            dbContext.School.Add(school);
            #endregion

            #region Create Parent
            var parent = new Parent
            {
                FirstName = "Büyük Veli",
                LastName = "Hazretleri",
                Birthday = new DateTime(1965, 06, 01)
            };

            dbContext.Parent.Add(parent);
            dbContext.SaveChanges();
            #endregion

            #region Create Teacher
            var teacher = new Teacher
            {
                FirstName = "İlk",
                LastName = "Öğretmen",
                Birthday = new DateTime(1980, 06, 01),
                SchoolId = school.Id
            };

            dbContext.Teacher.Add(teacher);
            dbContext.SaveChanges();
            #endregion

            #region Create Class
            var kindergartenClass = new Class
            {
                Name = "İlk Okul",
                School = school,
                Teacher = teacher
            };

            dbContext.Class.Add(kindergartenClass);
            dbContext.SaveChanges();
            #endregion

            dbContext.Student.Add(new Student
            {
                FirstName = "Ahmet I",
                LastName = "",
                Birthday = new DateTime(2018, 06, 12),
                School = school,
                Class = kindergartenClass,
                Parent = parent
            });

            dbContext.Student.Add(new Student
            {
                FirstName = "Ahmet II",
                LastName = "",
                Birthday = new DateTime(2017, 05, 12),
                School = school,
                Class = kindergartenClass,
                Parent = parent
            });

            dbContext.Student.Add(new Student
            {
                FirstName = "Hasan II",
                LastName = "",
                Birthday = new DateTime(2018, 04, 17),
                School = school,
                Class = kindergartenClass,
                Parent = parent
            });

            dbContext.Student.Add(new Student
            {
                FirstName = "Hüseyin II",
                LastName = "",
                Birthday = new DateTime(2015, 06, 12),
                School = school,
                Class = kindergartenClass,
                Parent = parent
            });

            dbContext.Student.Add(new Student
            {
                FirstName = "Merve II",
                LastName = "",
                Birthday = new DateTime(2018, 03, 12),
                School = school,
                Class = kindergartenClass,
                Parent = parent
            });

            dbContext.SaveChanges();
        }
        #endregion
    }
}
