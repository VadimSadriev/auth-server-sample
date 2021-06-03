using AuthServer.Common.Http.Clients;
using AuthServer.Common.Http.Clients.Identity;
using AuthServer.Common.Http.DelegatingHandlers;
using AuthServer.Common.Http.Serializers;
using Microsoft.Extensions.Configuration;
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
        public static IHttpClientBuilder AddApiClient<TClient, TImpl>(this IServiceCollection services)
            where TClient : class
            where TImpl : class, TClient
        {
            return services.AddHttpClient<TClient, TImpl>()
                .AddTypedClient<TClient, TImpl>();
        }

        /// <summary>
        /// Adds default api client services to Di
        /// </summary>
        public static IServiceCollection AddDefaultApiClients(this IServiceCollection services)
        {
            services.TryAddScoped<IJsonApiClient, JsonApiClient>();
            
            services.TryAddScoped<JsonModelSerializer>();

            return services;
        }

        /// <summary>
        /// Adds identity client to authenticate requests to identity server clients
        /// </summary>
        public static IServiceCollection AddIdentityApiClient(this IServiceCollection services, IConfigurationSection identitySeverConfigurationSection)
        {
            services.Configure<IdentityConfiguration>(identitySeverConfigurationSection);
            services.AddScoped<IdentityServerDelegatingHandler>();

            services.AddHttpClient<IIdentityApiClient, IdentityApiClient>()
                .AddTypedClient<IIdentityApiClient, IdentityApiClient>();

            return services;
        }
    }
}