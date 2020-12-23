using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="IdentityUserToken{T}"/>
    /// </summary>
    public class UserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken<long>>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<IdentityUserToken<long>> builder)
        {
            builder.ToTable("user_tokens");
        }
    }
}
