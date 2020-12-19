using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="ClientSecret"/>
    /// </summary>
    public class ClientSecretConfiguration : IEntityTypeConfiguration<ClientSecret>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ClientSecret> builder)
        {
            builder.ToTable("client_secrets");
        }
    }
}
