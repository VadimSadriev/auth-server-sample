using IdentityServer4.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServerEfCore.Configuration.DataLayer.Configuration
{
    /// <summary>
    /// EF core configuration for <see cref="ApiScope"/>
    /// </summary>
    public  class ApiScopeConfiguration : IEntityTypeConfiguration<ApiScope>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Configure(EntityTypeBuilder<ApiScope> builder)
        {
            builder.ToTable("api_scopes");
        }
    }
}
