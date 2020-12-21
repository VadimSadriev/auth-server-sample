using AuthServerEfCore.Entities;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthServerEfCore.DataLayer
{
    /// <summary>
    /// Main application data context
    /// </summary>
    public class DataContext : IdentityDbContext<User, Role, long>
    {
        /// <summary>
        /// <inheritdoc cref="DataContext"/>
        /// </summary>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
