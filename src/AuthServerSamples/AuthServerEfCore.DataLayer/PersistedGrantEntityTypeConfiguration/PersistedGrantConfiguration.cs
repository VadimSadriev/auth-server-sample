using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.PersistedGrant.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="IdentityServer4.EntityFramework.Entities.PersistedGrant"/>
    /// </summary>
    public class PersistedGrantConfiguration : IEntityTypeConfiguration<IdentityServer4.EntityFramework.Entities.PersistedGrant>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<IdentityServer4.EntityFramework.Entities.PersistedGrant> builder)
        {
            builder.ToTable("persisted_grants");
        }
    }
}
