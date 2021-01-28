using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.EntityTypeConfiguration
{
    /// <summary>
    /// Ef core configuration for <see cref="IdentityUserToken{T}"/>
    /// </summary>
    public class UserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            builder.ToTable("user_tokens");
        }
    }
}