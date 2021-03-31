using FF.Core.Services.Actions;
using FF.Core.Services.Activities;
using FF.Core.Services.Classes;
using FF.Core.Services.Students;
using FF.Data.Context.MySql;
using FF.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FF.Core.Infrastructure
{
    public static class StartupSetup
    {
        #region Methods
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString));
        }

        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IStudentActivityService, StudentActivityService>();
            services.AddScoped<IActionService, ActionService>();
            services.AddScoped<IClassService, ClassService>();
        }

        public static void EnsureDatabaseCreated(this IServiceCollection services)
        {
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var context = serviceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
                Seeder.Initialize(serviceProvider);
            }
        }
        #endregion
    }
}
