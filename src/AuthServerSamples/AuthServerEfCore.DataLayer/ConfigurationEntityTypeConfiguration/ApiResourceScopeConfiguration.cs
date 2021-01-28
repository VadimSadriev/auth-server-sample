using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.ConfigurationEntityTypeConfiguration
{
    /// <summary>
    /// Ef core configuration for <see cref="ApiResourceScope"/>
    /// </summary>
    public class ApiResourceScopeConfiguration : IEntityTypeConfiguration<ApiResourceScope>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ApiResourceScope> builder)
        {
            builder.ToTable("api_resource_scopes");
        }
    }
}
