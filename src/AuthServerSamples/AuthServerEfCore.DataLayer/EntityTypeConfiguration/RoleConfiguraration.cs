using AuthServerEfCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.EntityTypeConfiguration
{
    /// <summary>
    /// Ef core configuration for <see cref="Role"/>
    /// </summary>
    public class RoleConfiguraration : IEntityTypeConfiguration<Role>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");
        }
    }
}
