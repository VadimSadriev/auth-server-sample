using System.IO;
using System.Threading.Tasks;
using AuthServer.Common.Serialization.Exceptions;

namespace AuthServer.Common.Serialization
{
    /// <summary>
    /// Json serializer
    /// </summary>
    public interface IJsonSerializer
    {
        /// <summary>
        /// Serializes TModel into json string
        /// </summary>
        string Serialize<TModel>(TModel model);

        /// <summary>
        /// Deserializes json string into TModel
        /// </summary>
        /// <exception cref="JsonDeserializeException"> Error during deserialization </exception>
        TModel? Deserialize<TModel>(string jsonString);

        /// <summary>
        /// Deserializes stream into TModel
        /// </summary>
        /// <exception cref="JsonDeserializeException"> Error during deserialization </exception>
        ValueTask<TModel?> DeserializeAsync<TModel>(Stream stream);
    }
}