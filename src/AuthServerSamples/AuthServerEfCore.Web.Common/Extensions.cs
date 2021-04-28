using AuthServer.Common.Configuration;
using AuthServerEfCore.DataLayer;
using AuthServerEfCore.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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

        /// <summary>
        /// Adds identity server services to DI
        /// </summary>
        public static IServiceCollection AddIdentityServer(this IServiceCollection services, IConfigurationSection dbConnectionStringSection)
        {
            var connectionString = dbConnectionStringSection.EnsureExistence().Value;

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddAspNetIdentity<User>()
                .AddOperationalStore<PersistedGrantContext>(opts =>
                {
                    opts.ConfigureDbContext = dbConfig =>
                    {
                        dbConfig.UseNpgsql(connectionString);

                        dbConfig.EnableDetailedErrors();
                        dbConfig.EnableSensitiveDataLogging();
                    };
                })
                .AddConfigurationStore<ConfigurationContext>(opts =>
                {
                    opts.ConfigureDbContext = dbConfig =>
                    {
                        dbConfig.UseNpgsql(connectionString);

                        dbConfig.EnableDetailedErrors();
                        dbConfig.EnableSensitiveDataLogging();
                    };
                });
            
            services.Replace(ServiceDescriptor.Scoped<IPersistedGrantDbContext, PersistedGrantContext>());
            services.Replace(ServiceDescriptor.Scoped<IConfigurationDbContext, ConfigurationContext>());

            return services;
        }

        /// <summary>
        /// Adds identity services to Di such as User Manager etc
        /// </summary>
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(opts =>
                {
                    // TODO: Move to configuration
                    opts.Password.RequiredLength = 4;
                    opts.Password.RequireDigit = false;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}