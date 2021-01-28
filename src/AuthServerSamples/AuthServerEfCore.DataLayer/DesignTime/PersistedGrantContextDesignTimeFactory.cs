using System.IO;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace AuthServerEfCore.DataLayer.DesignTime
{
    /// <summary>
    /// Design time factory for <see cref="PersistedGrantContext"/>
    /// </summary>
    public class PersistedGrantContextDesignTimeFactory : DesignTimeDbContextFactory<PersistedGrantContext>
    {
        protected override string AppSettingsPath => $"{Directory.GetCurrentDirectory()}/../AuthServerEfCore.Web";
        protected override string ConfigurationName => "Database:ConnectionStrings:PersistedGrant";

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public override PersistedGrantContext CreateContext(DbContextOptions<PersistedGrantContext> options)
        {
            return new PersistedGrantContext(options, new OperationalStoreOptions());
        }
    }
}