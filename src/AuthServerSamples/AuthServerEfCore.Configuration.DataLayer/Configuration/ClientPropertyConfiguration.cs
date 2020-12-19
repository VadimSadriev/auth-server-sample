using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="ClientProperty"/>
    /// </summary>
    public class ClientPropertyConfiguration : IEntityTypeConfiguration<ClientProperty>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ClientProperty> builder)
        {
            builder.ToTable("client_properties");
        }
    }
}
