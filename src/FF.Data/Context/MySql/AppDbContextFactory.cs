using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FF.Data.Context.MySql
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql("Persist Security Info=False;" +
                "Username=qu95n9ynrko00izd;" +
                "Password=yobfn509daf92m3r;" +
                "database=c58ltmtfyam1uhxh;" +
                "server=d3y0lbg7abxmbuoi.chr7pe7iynqr.eu-west-1.rds.amazonaws.com;" +
                "Connect Timeout=3600;" +
                "SslMode=Required");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
