using AuthServerEfCore.DataLayer.PersistedGrantEntityTypeConfiguration;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace AuthServerEfCore.DataLayer
{
    /// <summary>
    /// Db context for operational data
    /// </summary>
    public class PersistedGrantContext : PersistedGrantDbContext<PersistedGrantContext>
    {
        /// <summary>
        /// <inheritdoc cref="PersistedGrantContext"/>
        /// </summary>
        public PersistedGrantContext(DbContextOptions<PersistedGrantContext> options, OperationalStoreOptions storeOptions) : base(options, storeOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DeviceFlowCodesConfiguration());
            modelBuilder.ApplyConfiguration(new PersistedGrantConfiguration());
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