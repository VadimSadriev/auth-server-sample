using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.ConfigurationEntityTypeConfiguration
{
    /// <summary>
    /// Ef core configration for <see cref="ApiResourceSecret"/>
    /// </summary>
    public class ApiResourceSecretConfiguration : IEntityTypeConfiguration<ApiResourceSecret>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ApiResourceSecret> builder)
        {
            builder.ToTable("api_resource_secrets");
        }
    }
}
