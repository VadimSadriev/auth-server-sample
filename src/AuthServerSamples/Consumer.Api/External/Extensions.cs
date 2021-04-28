using AuthServer.Common.Http;
using AuthServer.Common.Http.DelegatingHandlers;
using Consumer.Api.External.ApiClients.Order;
using Consumer.Api.External.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Consumer.Api.External
{
    public static class Extensions
    {
        /// <summary>
        /// Adds services for <see cref="IOrderApiClient"/> in Di
        /// </summary>
        public static IServiceCollection AddOrderApiClient(this IServiceCollection services, IConfigurationSection orderApiClientConfigurationSection)
        {
            services.Configure<OrderApiConfiguration>(orderApiClientConfigurationSection);

            services.AddApiClient<IOrderApiClient, OrderApiClient>()
                .AddHttpMessageHandler<IdentityServerDelegatingHandler>();

            return services;
        }
    }
}