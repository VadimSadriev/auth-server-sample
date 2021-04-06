using AuthServer.Common.Http.Clients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AuthServer.Common.Http
{
    /// <summary>
    /// Extensions methods for <see cref="IApiClient"/>
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adds typed api client to Di
        /// </summary>
        public static IHttpClientBuilder AddApiClient<TClient>(this IServiceCollection services)
            where TClient : class
        {
            return services.AddHttpClient<TClient>()
                .AddTypedClient<TClient>();
        }

        /// <summary>
        /// Adds default api client services to Di
        /// </summary>
        public static IServiceCollection AddDefaultApiClients(this IServiceCollection services)
        {
            services.TryAddScoped<IJsonApiClient, JsonApiClient>();

            return services;
        }
    }
}