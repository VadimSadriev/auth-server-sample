using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="IdentityUserLogin{T}"/>
    /// </summary>
    public class IdentityUserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<long>>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<IdentityUserLogin<long>> builder)
        {
            builder.ToTable("identity_user_logins");
        }
    }
}
