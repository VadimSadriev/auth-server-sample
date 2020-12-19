using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace AuthServerEfCore.Configuration.DataLayer
{
    /// <summary>
    /// Data context for operational data
    /// </summary>
    public class ConfigurationContext : ConfigurationDbContext<ConfigurationContext>
    {
        /// <summary>
        /// <inheritdoc cref="ConfigurationContext"/>
        /// </summary>
        public ConfigurationContext(DbContextOptions<ConfigurationContext> options, ConfigurationStoreOptions storeOptions) : base(options, storeOptions)
        {
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
    }
}
