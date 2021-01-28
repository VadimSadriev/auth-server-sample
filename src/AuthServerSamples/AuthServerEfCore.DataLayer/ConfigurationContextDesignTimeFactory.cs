using System.IO;
using AuthServerEfCore.DataLayer.Core;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace AuthServerEfCore.DataLayer
{
    /// <summary>
    /// Design time factory for <see cref="ConfigurationContext"/>
    /// </summary>
    public class ConfigurationContextDesignTimeFactory : DesignTimeDbContextFactory<ConfigurationContext>
    {
        protected override string AppSettingsPath => $"{Directory.GetCurrentDirectory()}/../AuthServerEfCore.Web";
        protected override string ConfigurationName => "Database:ConnectionStrings:Configuration";

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public override ConfigurationContext CreateContext(DbContextOptions<ConfigurationContext> options)
        {
            return new ConfigurationContext(options, new ConfigurationStoreOptions());
        }
    }
}