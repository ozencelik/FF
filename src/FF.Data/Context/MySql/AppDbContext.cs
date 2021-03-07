using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FF.Data.Context.MySql
{
    public class AppDbContext : DbContext
    {
        #region Fields
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
