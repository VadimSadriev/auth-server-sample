using AuthServer.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Exceptions;

namespace AuthServer.Common.Logging
{
    /// <summary>
    /// Extends method for logging
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// Replaces all logging providers with serilog logging provider
        /// </summary>
        public static IServiceCollection AddSerilog(this IServiceCollection services, IConfigurationSection loggingSection)
        {
            return services.AddLogging(builder =>
             {
                 builder.ClearProviders();
                 builder.AddSerilog(
                     new LoggerConfiguration()
                     .ReadFrom.Configuration(loggingSection.EnsureExistence())
                     .Enrich.WithExceptionDetails()
                     .CreateLogger());
             });
        }
    }
}
