using System;
using System.Net.Http;
using System.Threading.Tasks;
using AuthServer.Common.Http.Serializers;
using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace AuthServer.Common.Http.Clients.Identity
{
    /// <inheritdoc cref="IIdentityApiClient"/>
    public class IdentityApiClient : JsonApiClient, IIdentityApiClient
    {
        private readonly IOptions<IdentityConfiguration> _options;

        /// <inheritdoc cref="IdentityApiClient"/>
        public IdentityApiClient(
            JsonModelSerializer serializer,
            HttpClient httpClient,
            IOptions<IdentityConfiguration> options)
            : base(serializer, httpClient)
        {
            _options = options;
            httpClient.BaseAddress = new Uri(_options.Value.Authority);
        }

        /// <inheritdoc />
        public async Task<string>  GetAccessTokenAsync()
        {
            var discoveryDocument = await HttpClient.GetDiscoveryDocumentAsync(_options.Value.Authority);

            var tokenResponse = await HttpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = _options.Value.ClientId,
                ClientSecret = _options.Value.ClientSecret,
                Scope = _options.Value.Scope
            });

            return tokenResponse.AccessToken;
        }
    }
}