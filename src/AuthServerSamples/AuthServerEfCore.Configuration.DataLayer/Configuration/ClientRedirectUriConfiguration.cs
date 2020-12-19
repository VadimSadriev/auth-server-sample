using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="ClientRedirectUri"/>
    /// </summary>
    public class ClientRedirectUriConfiguration : IEntityTypeConfiguration<ClientRedirectUri>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ClientRedirectUri> builder)
        {
            builder.ToTable("client_redirect_uries");
        }
    }
}
