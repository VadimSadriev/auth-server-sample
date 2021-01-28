using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.ConfigurationEntityTypeConfiguration
{
    /// <summary>
    /// Ef core configuration for <see cref="IdentityResource"/>
    /// </summary>
    public class IdentityResourceConfiguration : IEntityTypeConfiguration<IdentityResource>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<IdentityResource> builder)
        {
            builder.ToTable("identity_resources");
        }
    }
}
