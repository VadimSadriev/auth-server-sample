using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="ClientPostLogoutRedirectUri"/>
    /// </summary>
    public class ClientPostLogoutRedirectUriConfiguration : IEntityTypeConfiguration<ClientPostLogoutRedirectUri>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ClientPostLogoutRedirectUri> builder)
        {
            builder.ToTable("client_post_logout_redirect_uries");
        }
    }
}
