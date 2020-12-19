using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
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
