using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
{
    /// <summary>
    /// EF core confugration for <see cref="ApiScopeClaim"/>
    /// </summary>
    public class ApiScopeClaimConfiguration : IEntityTypeConfiguration<ApiScopeClaim>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ApiScopeClaim> builder)
        {
            builder.ToTable("api_scope_claims");
        }
    }
}
