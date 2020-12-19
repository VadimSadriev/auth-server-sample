using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="ClientIdPRestriction"/>
    /// </summary>
    public class ClientIdRestrictionConfiguration : IEntityTypeConfiguration<ClientIdPRestriction>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ClientIdPRestriction> builder)
        {
            builder.ToTable("client_id_restrictions");
        }
    }
}
