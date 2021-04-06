using System;
using System.Net.Http;
using AuthServer.Common.Http.Clients;
using AuthServer.Common.Http.Serializers;
using Consumer.Api.External.Configuration;
using Microsoft.Extensions.Options;

namespace Consumer.Api.External.ApiClients.Identity
{
    /// <inheritdoc cref="IIdentityApiClient"/>
    public class IdentityApiClient : JsonApiClient, IIdentityApiClient
    {
        /// <inheritdoc cref="IdentityApiClient"/>
        public IdentityApiClient(
            JsonModelSerializer serializer,
            HttpClient httpClient,
            IOptions<IdentityConfiguration> options)
            : base(serializer, httpClient)
        {
            httpClient.BaseAddress = new Uri(options.Value.Authority);
        }
    }
}