using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.ConfigurationEntityTypeConfiguration
{
    /// <summary>
    /// Ef core configuration for <see cref="ClientScope"/>
    /// </summary>
    public class ClientScopeConfiguration : IEntityTypeConfiguration<ClientScope>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ClientScope> builder)
        {
            builder.ToTable("client_scopes");
        }
    }
}
