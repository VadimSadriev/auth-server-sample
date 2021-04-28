using System.Net.Http;
using System.Threading.Tasks;
using AuthServer.Common.Http.Clients.Identity;

namespace AuthServer.Common.Http.DelegatingHandlers
{
    /// <summary>
    /// Delegating handler to authenticate request to Identity server client
    /// </summary>
    public class IdentityServerDelegatingHandler : AuthDelegatingHandler
    {
        private readonly IIdentityApiClient _identityApiClient;

        private string? _accessToken;

        public IdentityServerDelegatingHandler(IIdentityApiClient identityApiClient)
        {
            _identityApiClient = identityApiClient;
        }

        /// <inheritdoc />
        protected override async Task AuthorizeAsync(HttpRequestMessage httpRequestMessage)
        {
            _accessToken ??= await _identityApiClient.GetAccessTokenAsync();
        }

        /// <inheritdoc />
        protected override async Task OnUnauthorizedAsync(HttpRequestMessage httpRequestMessage, HttpResponseMessage httpResponseMessage)
        {
            _accessToken = await _identityApiClient.GetAccessTokenAsync();
        }
    }
}