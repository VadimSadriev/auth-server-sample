using AuthServerEfCore.DataLayer.ConfigurationEntityTypeConfiguration;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace AuthServerEfCore.DataLayer
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
            modelBuilder.ApplyConfiguration(new ApiResourceClaimConfiguration());
            modelBuilder.ApplyConfiguration(new ApiResourceConfiguration());
            modelBuilder.ApplyConfiguration(new ApiResourcePropertyConfiguration());
            modelBuilder.ApplyConfiguration(new ApiResourceScopeConfiguration());
            modelBuilder.ApplyConfiguration(new ApiResourceSecretConfiguration());
            modelBuilder.ApplyConfiguration(new ApiScopeClaimConfiguration());
            modelBuilder.ApplyConfiguration(new ApiScopeConfiguration());
            modelBuilder.ApplyConfiguration(new ApiScopePropertyConfiguration());
            modelBuilder.ApplyConfiguration(new ClientClaimConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ClientCorsOriginConfiguration());
            modelBuilder.ApplyConfiguration(new ClientGrantTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClientIdRestrictionConfiguration());
            modelBuilder.ApplyConfiguration(new ClientPostLogoutRedirectUriConfiguration());
            modelBuilder.ApplyConfiguration(new ClientPropertyConfiguration());
            modelBuilder.ApplyConfiguration(new ClientRedirectUriConfiguration());
            modelBuilder.ApplyConfiguration(new ClientScopeConfiguration());
            modelBuilder.ApplyConfiguration(new ClientSecretConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityResourceClaimConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityResourcePropertyConfiguration());
            modelBuilder.ApplyConfiguration(new IdentityResourceConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
    }
}
