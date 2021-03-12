using System.Net.Http;
using System.Threading.Tasks;

namespace AuthServer.Common.Http
{
    /// <summary>
    /// Serializer for http request
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serializes <paramref name="request"/> into <paramref name="requestMessage"/>
        /// </summary>
        ValueTask SerializeAsync<TRequest>(TRequest request, HttpRequestMessage requestMessage);

        /// <summary>
        /// Deserializes <paramref name="responseMessage"/> into TResponse
        /// </summary>
        ValueTask<TResponse?> DeserializeAsync<TResponse>(HttpResponseMessage responseMessage);
    }
}