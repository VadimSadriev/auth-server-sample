using System;
using System.Net.Http;
using AuthServer.Common.Http.Clients;
using AuthServer.Common.Http.Serializers;
using Consumer.Api.External.Configuration;
using Microsoft.Extensions.Options;

namespace Consumer.Api.External.ApiClients.Order
{
    /// <inheritdoc cref="IOrderApiClient"/>
    public class OrderApiClient : JsonApiClient, IOrderApiClient
    {
        private readonly IOptions<OrderApiConfiguration> _options;

        /// <inheritdoc cref="OrderApiClient"/>
        public OrderApiClient(
            JsonModelSerializer serializer,
            HttpClient httpClient,
            IOptions<OrderApiConfiguration> options)
            : base(serializer, httpClient)
        {
            _options = options;
            httpClient.BaseAddress = new Uri(_options.Value.Endpoint);
        }
    }
}