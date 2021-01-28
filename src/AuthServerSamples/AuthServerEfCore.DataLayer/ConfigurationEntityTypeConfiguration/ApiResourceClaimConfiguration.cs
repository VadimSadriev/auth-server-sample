using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.ConfigurationEntityTypeConfiguration
{
    /// <summary>
    /// Ef core configuration for <see cref="ApiResourceClaim"/>
    /// </summary>
    public class ApiResourceClaimConfiguration : IEntityTypeConfiguration<ApiResourceClaim>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ApiResourceClaim> builder)
        {
            builder.ToTable("api_resource_claims");
        }
    }
}
