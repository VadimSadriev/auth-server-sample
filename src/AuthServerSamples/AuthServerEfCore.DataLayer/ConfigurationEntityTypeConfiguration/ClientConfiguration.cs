using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.ConfigurationEntityTypeConfiguration
{
    /// <summary>
    /// EF core configuration for <see cref="Client`"/>
    /// </summary>
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clients");
        }
    }
}
