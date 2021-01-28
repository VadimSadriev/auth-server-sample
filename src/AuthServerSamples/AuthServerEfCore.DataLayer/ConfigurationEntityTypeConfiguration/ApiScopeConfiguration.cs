using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.ConfigurationEntityTypeConfiguration
{
    /// <summary>
    /// EF core configuration for <see cref="ApiScope"/>
    /// </summary>
    public  class ApiScopeConfiguration : IEntityTypeConfiguration<ApiScope>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ApiScope> builder)
        {
            builder.ToTable("api_scopes");
        }
    }
}
