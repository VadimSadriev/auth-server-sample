using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuthServer.Common.Serialization;

namespace AuthServer.Common.Http.Serializers
{
    /// <summary>
    /// Json serializer for <see cref="HttpRequestMessage"/>
    /// </summary>
    public class JsonModelSerializer : ISerializer
    {
        private readonly IJsonSerializer _jsonSerializer;

        /// <inheritdoc cref="JsonModelSerializer"/>
        public JsonModelSerializer(IJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        /// <inheritdoc />
        public ValueTask SerializeAsync<TRequest>(TRequest request, HttpRequestMessage requestMessage)
        {
            var jsonString = _jsonSerializer.Serialize(request);

            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            requestMessage.Content = stringContent;

            return new ValueTask();
        }

        /// <inheritdoc />
        public async ValueTask<TResponse?> DeserializeAsync<TResponse>(HttpResponseMessage responseMessage)
        {
            var resultStream = await responseMessage.Content.ReadAsStreamAsync();

            return await _jsonSerializer.DeserializeAsync<TResponse>(resultStream);
        }
    }
}