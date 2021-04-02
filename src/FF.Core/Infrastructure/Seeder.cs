using FF.Data.Context.MySql;
using FF.Data.Entities.Activities;
using FF.Data.Entities.Classes;
using FF.Data.Entities.SchoolBuses;
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
            dbContext.SaveChanges();
            #endregion

            #region Create Teacher
            var teacher = new Teacher
            {
                FirstName = "İlk",
                LastName = "Öğretmen",
                Birthday = new DateTime(1980, 06, 01)
            };

            dbContext.Teacher.Add(teacher);
            dbContext.SaveChanges();
            #endregion

            #region Create School Bus
            var schoolBus = new SchoolBus
            {
                FirstName = "İlk",
                LastName = "Öğretmen",
                Birthday = new DateTime(1980, 06, 01),
                LicensePlate = "35 ABC 78",
                PhoneNumber = "0555 555 55 55",
                CompanyName = "Hızlı Servis",
                SchoolId = school.Id
            };

            var schoolBus1 = new SchoolBus
            {
                FirstName = "İlk",
                LastName = "Öğretmen",
                Birthday = new DateTime(1980, 06, 01),
                LicensePlate = "35 ABC 78",
                PhoneNumber = "0555 555 55 55",
                CompanyName = "Hızlı Servis 1",
                SchoolId = school.Id
            };

            dbContext.SchoolBus.Add(schoolBus);
            dbContext.SchoolBus.Add(schoolBus1);
            dbContext.SaveChanges();
            #endregion

            #region Create Class
            var kindergartenClass = new Class
            {
                Name = "1-A",
                School = school,
                Teacher = teacher
            };

            var kindergartenClass1 = new Class
            {
                Name = "2-A",
                School = school,
                Teacher = teacher
            };

            dbContext.Class.Add(kindergartenClass);
            dbContext.Class.Add(kindergartenClass1);
            dbContext.SaveChanges();
            #endregion

            #region Create Student
            dbContext.Student.Add(new Student
            {
                FirstName = "Ahmet I",
                LastName = "",
                Birthday = new DateTime(2018, 06, 12),
                Class = kindergartenClass,
                SchoolBus = schoolBus,
                ParentFirstName = "Büyük Veli",
                ParentLastName = "Hazretleri",
                ParentPhoneNumber = "111111111",
                ParentEmail = "abc@mail.com"
            });

            dbContext.Student.Add(new Student
            {
                FirstName = "Merve II",
                LastName = "",
                Birthday = new DateTime(2017, 05, 12),
                Class = kindergartenClass,
                SchoolBus = schoolBus,
                ParentFirstName = "Büyük Veli",
                ParentLastName = "Hazretleri",
                ParentPhoneNumber = "111111111",
                ParentEmail = "abc@mail.com"
            });
            #endregion

            #region Create Activities
            var mealActivity = new Activity
            {
                Name = "Yemek Aktivitesi"
            };
            var sleepActivity = new Activity
            {
                Name = "Uyku Aktivitesi"
            };
            var serviceActivity = new Activity
            {
                Name = "Servis Aktivitesi"
            };
            var medicineActivity = new Activity
            {
                Name = "İlaç Aktivitesi"
            };

            dbContext.Activity.Add(mealActivity);
            dbContext.Activity.Add(sleepActivity);
            dbContext.Activity.Add(serviceActivity);
            dbContext.Activity.Add(medicineActivity);

            dbContext.SaveChanges();
            #endregion

            #region Create Activity Options
            var mealActivityOption1 = new ActivityOption { Name = "Yemedi", ActivityId = mealActivity.Id };
            var mealActivityOption2 = new ActivityOption { Name = "Kısmen", ActivityId = mealActivity.Id };
            var mealActivityOption3 = new ActivityOption { Name = "Bitirdi", ActivityId = mealActivity.Id };

            var sleepActivityOption1 = new ActivityOption { Name = "Uyumadı", ActivityId = sleepActivity.Id };
            var sleepActivityOption2 = new ActivityOption { Name = "Uyudu", ActivityId = sleepActivity.Id };

            var serviceActivityOption1 = new ActivityOption { Name = "Binmedi", ActivityId = serviceActivity.Id };
            var serviceActivityOption2 = new ActivityOption { Name = "Bindi", ActivityId = serviceActivity.Id };
            var serviceActivityOption3 = new ActivityOption { Name = "İndi", ActivityId = serviceActivity.Id };

            var medicineActivityOption1 = new ActivityOption { Name = "Aldı", ActivityId = medicineActivity.Id };
            var medicineActivityOption2 = new ActivityOption { Name = "Almadı", ActivityId = medicineActivity.Id };

            dbContext.ActivityOption.Add(mealActivityOption1);
            dbContext.ActivityOption.Add(mealActivityOption2);
            dbContext.ActivityOption.Add(mealActivityOption3);
            dbContext.SaveChanges();

            dbContext.ActivityOption.Add(sleepActivityOption1);
            dbContext.ActivityOption.Add(sleepActivityOption2);
            dbContext.SaveChanges();

            dbContext.ActivityOption.Add(serviceActivityOption1);
            dbContext.ActivityOption.Add(serviceActivityOption2);
            dbContext.ActivityOption.Add(serviceActivityOption3);
            dbContext.SaveChanges();

            dbContext.ActivityOption.Add(medicineActivityOption1);
            dbContext.ActivityOption.Add(medicineActivityOption2);
            dbContext.SaveChanges();
            #endregion

            dbContext.SaveChanges();
        }
        #endregion
    }
}
