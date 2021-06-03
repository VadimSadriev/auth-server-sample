using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using AuthServer.Common.Extensions;
using AuthServer.Common.Http.Exceptions;
using Microsoft.AspNetCore.WebUtilities;

namespace AuthServer.Common.Http
{
    /// <inheritdoc cref="IApiClient"/>
    public class ApiClient<TSerializer> : IApiClient
        where TSerializer : ISerializer
    {
        private readonly TSerializer _serializer;
        protected readonly HttpClient HttpClient;

        private static ConcurrentDictionary<Type, IEnumerable<PropertyInfo>> _typePropertyInfosDic = new();

        /// <inheritdoc cref="ApiClient{TSerializer}"/>
        public ApiClient(
            TSerializer serializer,
            HttpClient httpClient
        )
        {
            _serializer = serializer;
            HttpClient = httpClient;
        }
        /// <inheritdoc />
        public async Task<TResponse?> SendAsync<TRequest, TResponse>(TRequest? request, HttpMethod httpMethod, string uri)
        {
            if (httpMethod == HttpMethod.Get)
                uri = SerializeRequestModelToUri(request, uri);

            var requestMessage = new HttpRequestMessage
            {
                Method = httpMethod,
                RequestUri = new Uri(uri, UriKind.RelativeOrAbsolute)
            };

            if (request != null && httpMethod != HttpMethod.Get)
                await _serializer.SerializeAsync(request, requestMessage);

            try
            {
                var responseMessage = await HttpClient.SendAsync(requestMessage);

                responseMessage.EnsureSuccessStatusCode();

                var response = await _serializer.DeserializeAsync<TResponse>(responseMessage);

                return response;
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException)
            {
                throw new ApiException();
            }
        }

        /// <summary>
        /// Serializes model to uri paramters
        /// </summary>
        private string SerializeRequestModelToUri<TRequest>(TRequest request, string uri)
        {
            var queryParameters = new List<KeyValuePair<string, string?>>();

            var requestType = typeof(TRequest);

            var requestProperties = _typePropertyInfosDic.GetOrAdd(requestType, type => type.GetProperties());

            foreach (var requestProperty in requestProperties)
            {
                var propValue = requestProperty.GetValue(request);

                if (propValue == null)
                    continue;

                if (requestProperty.IsEnumerable())
                {
                    var enumerable = (IEnumerable)propValue;

                    foreach (var item in enumerable)
                    {
                        queryParameters.Add(new KeyValuePair<string, string?>(requestProperty.Name, item.ToString()!));
                    }

                    continue;
                }

                if (requestProperty.IsClass())
                    continue;

                queryParameters.Add(new KeyValuePair<string, string?>(requestProperty.Name, propValue.ToString()!));
            }

            return QueryHelpers.AddQueryString(uri, queryParameters);
        }
    }
}