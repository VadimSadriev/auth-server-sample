using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AuthServer.Common.Http.DelegatingHandlers
{
    /// <summary>
    /// Base class for handling authentication in http request pipeline
    /// </summary>
    public abstract class AuthDelegatingHandler : DelegatingHandler
    {
        /// <inheritdoc />
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            await AuthorizeAsync(request);
            
            var result = await base.SendAsync(request, cancellationToken);

            switch (result.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    await OnUnauthorizedAsync(request, result);
                    break;
            }

            return await base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// Authorizes <see cref="HttpRequestMessage"/>
        /// </summary>
        protected abstract Task AuthorizeAsync(HttpRequestMessage httpRequestMessage);

        /// <summary>
        /// Handles on unauthorized response
        /// </summary>
        protected abstract Task OnUnauthorizedAsync(HttpRequestMessage httpRequestMessage, HttpResponseMessage httpResponseMessage);
    }
    
}