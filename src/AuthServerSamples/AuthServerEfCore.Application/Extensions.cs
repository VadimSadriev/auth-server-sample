using AuthServerEfCore.Application.Migrator;
using Microsoft.Extensions.DependencyInjection;

namespace AuthServerEfCore.Application
{
    /// <summary>
    /// Extension methods for application layer
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adds application layer services to DI
        /// </summary>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMigratorService, MigratorService>();

            services.Scan(x => x.FromCallingAssembly()
                .AddClasses(classes => classes.AssignableTo<ISeeder>())
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            return services;
        }
    }
}