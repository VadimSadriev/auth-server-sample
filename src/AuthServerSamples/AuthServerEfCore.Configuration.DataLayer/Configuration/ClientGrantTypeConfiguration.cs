using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="ClientGrantType"/>
    /// </summary>
    public class ClientGrantTypeConfiguration : IEntityTypeConfiguration<ClientGrantType>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ClientGrantType> builder)
        {
            builder.ToTable("client_grant_types");
        }
    }
}
