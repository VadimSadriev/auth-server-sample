using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.ConfigurationEntityTypeConfiguration
{
    /// <summary>
    /// Ef core configuration for <see cref="IdentityResourceProperty"/>
    /// </summary>
    public class IdentityResourcePropertyConfiguration : IEntityTypeConfiguration<IdentityResourceProperty>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<IdentityResourceProperty> builder)
        {
            builder.ToTable("identity_resource_properties");
        }
    }
}
