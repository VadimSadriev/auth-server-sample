using System.Net.Http;
using AuthServer.Common.Http.Serializers;

namespace AuthServer.Common.Http.Clients
{
    /// <inheritdoc cref="IJsonApiClient"/>
    public class JsonApiClient : ApiClient<JsonModelSerializer>, IJsonApiClient
    {
        /// <inheritdoc cref="JsonApiClient"/>
        public JsonApiClient(
            JsonModelSerializer serializer,
            HttpClient httpClient)
            : base(serializer, httpClient)
        {
        }
    }
}