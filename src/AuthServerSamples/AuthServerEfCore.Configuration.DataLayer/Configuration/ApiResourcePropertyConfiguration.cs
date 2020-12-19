using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="ApiResourceProperty"/>
    /// </summary>
    public class ApiResourcePropertyConfiguration : IEntityTypeConfiguration<ApiResourceProperty>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ApiResourceProperty> builder)
        {
            builder.ToTable("api_resource_properties");
        }
    }
}
