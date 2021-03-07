using FF.Data.Entities.Classes;
using FF.Data.Entities.Parents;
using FF.Data.Entities.SchoolBusAttendants;
using FF.Data.Entities.Schools;
using FF.Data.Entities.StudentActivities;
using FF.Data.Entities.Students;
using FF.Data.Entities.Teachers;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FF.Data.Context.MySql
{
    public class AppDbContext : DbContext
    {
        #region Fields
        public DbSet<Class> Class { get; set; }

        public DbSet<Parent> Parent { get; set; }

        public DbSet<SchoolBusAttendant> SchoolBusAttendant { get; set; }

        public DbSet<School> School { get; set; }

        public DbSet<Activity> Activity { get; set; }

        public DbSet<Meal> Meal { get; set; }

        public DbSet<Medicine> Medicine { get; set; }

        public DbSet<Service> Service { get; set; }

        public DbSet<Sleep> Sleep { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Teacher> Teacher { get; set; }
        #endregion

        #region Ctor
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        #endregion

        #region Methods
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return result;
        }
        #endregion
    }
}
