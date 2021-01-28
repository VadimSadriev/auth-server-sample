using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.ConfigurationEntityTypeConfiguration
{
    /// <summary>
    /// Ef core configuration for <see cref="ApiResource"/>
    /// </summary>
    public class ApiResourceConfiguration : IEntityTypeConfiguration<ApiResource>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ApiResource> builder)
        {
            builder.ToTable("api_resources");
        }
    }
}
