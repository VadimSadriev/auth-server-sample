using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="IdentityResourceClaim"/>
    /// </summary>
    public class IdentityResouceClaimConfiguration : IEntityTypeConfiguration<IdentityResourceClaim>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<IdentityResourceClaim> builder)
        {
            builder.ToTable("identity_resource_claims");
        }
    }
}
