using FF.Data.Entities.Activities;
using FF.Data.Entities.Classes;
using FF.Data.Entities.SchoolBuses;
using FF.Data.Entities.Schools;
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

        public DbSet<SchoolBus> SchoolBus { get; set; }

        public DbSet<SchoolBusStudent> SchoolBusStudent { get; set; }

        public DbSet<School> School { get; set; }

        public DbSet<Activity> Activity { get; set; }

        public DbSet<ActivityOption> ActivityOption { get; set; }

        public DbSet<StudentActivity> StudentActivity { get; set; }

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
