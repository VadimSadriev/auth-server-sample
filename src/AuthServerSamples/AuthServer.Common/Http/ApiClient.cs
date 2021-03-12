using System;
using System.Net.Http;
using System.Threading.Tasks;
using AuthServer.Common.Http.Exceptions;

namespace AuthServer.Common.Http
{
    /// <inheritdoc cref="IApiClient"/>
    public class ApiClient<TSerializer> : IApiClient
        where TSerializer : ISerializer
    {
        private readonly TSerializer _serializer;
        private readonly HttpClient _httpClient;

        /// <inheritdoc cref="ApiClient{TSerializer}"/>
        public ApiClient(
            TSerializer serializer,
            HttpClient httpClient
        )
        {
            _serializer = serializer;
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public async Task<TResponse?> SendAsync<TRequest, TResponse>(TRequest? request, HttpMethod httpMethod, string uri)
        {
            if (httpMethod == HttpMethod.Get)
                uri = SerializeRequestToUri(request, uri);

            var requestMessage = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(uri)
            };

            if (request != null)
                await _serializer.SerializeAsync(request, requestMessage);

            try
            {
                var responseMessage = await _httpClient.SendAsync(requestMessage);

                var response = await _serializer.DeserializeAsync<TResponse>(responseMessage);

                return response;
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException)
            {
                throw new ApiException();
            }
        }

        private string SerializeRequestToUri<TRequest>(TRequest request, string uri)
        {
            return default;
        }
    }
}