using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AuthServer.Common.Serialization.Exceptions;

namespace AuthServer.Common.Serialization
{
    /// <inheritdoc cref="IJsonSerializer"/>
    public class JsonSerializer : IJsonSerializer
    {
        private static readonly JsonSerializerOptions _defaultOptions;

        /// <inheritdoc cref="JsonSerializer"/>
        static JsonSerializer()
        {
            _defaultOptions = GetDefaultOptions();
        }

        /// <inheritdoc />
        public string Serialize<TModel>(TModel model)
        {
            return System.Text.Json.JsonSerializer.Serialize(model, _defaultOptions);
        }

        /// <inheritdoc />
        public TModel? Deserialize<TModel>(string jsonString)
        {
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<TModel>(jsonString, _defaultOptions);
            }
            catch (Exception exception) when (exception is JsonException || exception is NotSupportedException || exception is ArgumentNullException)
            {
                throw new JsonDeserializeException($"Error occured during deserialization into {typeof(TModel)}", jsonString, exception);
            }
        }

        /// <inheritdoc />
        public ValueTask<TModel?> DeserializeAsync<TModel>(Stream stream)
        {
            return System.Text.Json.JsonSerializer.DeserializeAsync<TModel>(stream, _defaultOptions);
        }

        /// <summary>
        /// Return default json serialization options
        /// </summary>
        private static JsonSerializerOptions GetDefaultOptions()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNameCaseInsensitive = true
            };

            options.Converters.Add(new JsonStringEnumConverter());

            return options;
        }
    }
}