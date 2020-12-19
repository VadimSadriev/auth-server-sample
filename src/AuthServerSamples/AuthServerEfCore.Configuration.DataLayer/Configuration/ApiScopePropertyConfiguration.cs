using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
{
    /// <summary>
    /// Ef core configuration for <see cref="ApiScopeProperty"/>
    /// </summary>
    public class ApiScopePropertyConfiguration : IEntityTypeConfiguration<ApiScopeProperty>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ApiScopeProperty> builder)
        {
            builder.ToTable("api_scope_properties");
        }
    }
}
