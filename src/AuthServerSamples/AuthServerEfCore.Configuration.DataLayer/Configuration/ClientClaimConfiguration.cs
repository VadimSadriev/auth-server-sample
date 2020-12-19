using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="ClientClaim"/>
    /// </summary>
    public class ClientClaimConfiguration : IEntityTypeConfiguration<ClientClaim>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ClientClaim> builder)
        {
            builder.ToTable("client_claims");
        }
    }
}
