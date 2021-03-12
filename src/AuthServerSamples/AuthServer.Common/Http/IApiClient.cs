using System.Net.Http;
using System.Threading.Tasks;
using AuthServer.Common.Http.Exceptions;

namespace AuthServer.Common.Http
{
    /// <summary>
    /// Api client for making http requests
    /// </summary>
    public interface IApiClient
    {
        /// <summary>
        /// Sends Http get request asynchronously
        /// </summary>
        /// <exception cref="ApiException"> Thrown during bad/invalid http request </exception>
        Task<TResponse?> GetAsync<TResponse>(string uri)
            => SendAsync<object, TResponse>(null, HttpMethod.Get, uri);

        /// <summary>
        /// Sends Http get request asynchronously
        /// </summary>
        /// <exception cref="ApiException"> Thrown during bad/invalid http request </exception>
        Task<TResponse?> GetAsync<TRequest, TResponse>(TRequest request, string uri)
            => SendAsync<TRequest, TResponse>(request, HttpMethod.Get, uri);

        /// <summary>
        /// Sends Http patch request asynchronously
        /// </summary>
        /// <exception cref="ApiException"> Thrown during bad/invalid http request </exception>
        Task<TResponse?> PatchAsync<TRequest, TResponse>(TRequest request, string uri)
            => SendAsync<TRequest, TResponse>(request, HttpMethod.Patch, uri);

        /// <summary>
        /// Sends Http patch request asynchronously
        /// </summary>
        /// <exception cref="ApiException"> Thrown during bad/invalid http request </exception>
        Task PatchAsync<TRequest>(TRequest request, string uri)
            => SendAsync<TRequest, object>(request, HttpMethod.Patch, uri);

        /// <summary>
        /// Sends Http post request asynchronously
        /// </summary>
        /// <exception cref="ApiException"> Thrown during bad/invalid http request </exception>
        Task PostAsync<TRequest>(TRequest request, string uri)
            => SendAsync<TRequest, object>(request, HttpMethod.Post, uri);

        /// <summary>
        /// Sends Http post request asynchronously
        /// </summary>
        /// <exception cref="ApiException"> Thrown during bad/invalid http request </exception>
        Task<TResponse?> PostAsync<TRequest, TResponse>(TRequest request, string uri)
            => SendAsync<TRequest, TResponse>(request, HttpMethod.Post, uri);

        /// <summary>
        /// Sends Http put request asynchronously
        /// </summary>
        /// <exception cref="ApiException"> Thrown during bad/invalid http request </exception>
        Task<TResponse?> PutAsync<TRequest, TResponse>(TRequest request, string uri)
            => SendAsync<TRequest, TResponse>(request, HttpMethod.Put, uri);

        /// <summary>
        /// Sends Http put request asynchronously
        /// </summary>
        /// <exception cref="ApiException"> Thrown during bad/invalid http request </exception>
        Task PutAsync<TRequest>(TRequest request, string uri)
            => SendAsync<TRequest, object>(request, HttpMethod.Put, uri);

        /// <inheritdoc cref="SendAsync{TRequest,TResponse}"/>
        Task SendAsync<TRequest>(TRequest request, HttpMethod httpMethod, string uri)
            => SendAsync<TRequest, object>(request, httpMethod, uri);

        /// <inheritdoc cref="SendAsync{TRequest,TResponse}"/>
        Task<TResponse?> SendAsync<TResponse>(HttpMethod httpMethod, string uri)
            => SendAsync<object, TResponse>(null, httpMethod, uri);

        /// <summary>
        /// Sends http request asynchronously
        /// </summary>
        /// <exception cref="ApiException"> Thrown during bad/invalid http request </exception>
        Task<TResponse?> SendAsync<TRequest, TResponse>(TRequest? request, HttpMethod httpMethod, string uri);
    }
}