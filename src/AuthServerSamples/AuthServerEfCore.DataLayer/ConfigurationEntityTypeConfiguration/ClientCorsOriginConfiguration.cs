using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.ConfigurationEntityTypeConfiguration
{
    /// <summary>
    /// Ef core configuration for <see cref="ClientCorsOrigin"/>
    /// </summary>
    public class ClientCorsOriginConfiguration : IEntityTypeConfiguration<ClientCorsOrigin>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ClientCorsOrigin> builder)
        {
            builder.ToTable("client_cors_origins");
        }
    }
}
