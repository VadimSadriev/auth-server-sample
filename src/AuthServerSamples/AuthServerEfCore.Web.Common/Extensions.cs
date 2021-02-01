using AuthServer.Common.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServerEfCore.Web.Common
{
    /// <summary>
    /// Extension methods for Web.Common layer
    /// <remarks>
    /// Mainly this class exists for Di registration
    /// </remarks>
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adds db context to Di
        /// </summary>
        public static IServiceCollection AddDbContext<TDataContext>(this IServiceCollection services, IConfigurationSection conStringSection)
            where TDataContext : DbContext
        {
            conStringSection.EnsureExistence();

            services.AddDbContext<TDataContext>(opts =>
            {
                opts.UseNpgsql(conStringSection.Value);
                opts.EnableSensitiveDataLogging();
                opts.EnableDetailedErrors();
            });

            return services;
        }
    }
}