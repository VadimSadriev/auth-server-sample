using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace AuthServerEfCore.PersistedGrant.DataLayer
{
    /// <summary>
    /// Db context for operational data
    /// </summary>
    public class PersistedGrantContext : PersistedGrantDbContext
    {
        /// <summary>
        /// <inheritdoc cref="PersistedGrantContext"/>
        /// </summary>
        public PersistedGrantContext(DbContextOptions<PersistedGrantDbContext> options, OperationalStoreOptions storeOptions) : base(options, storeOptions)
        {
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
    }
}
