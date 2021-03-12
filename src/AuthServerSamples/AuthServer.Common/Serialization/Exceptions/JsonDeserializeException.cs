using System;

namespace AuthServer.Common.Serialization.Exceptions
{
    /// <summary>
    /// Thrown if error occured during json deserialization
    /// </summary>
    public class JsonDeserializeException : Exception
    {
        /// <summary>
        /// <inheritdoc cref="JsonDeserializeException"/>
        /// </summary>
        public JsonDeserializeException(string input, Exception innerException)
            : this("Error during deserilization from json string", input, innerException)
        {
        }

        /// <summary>
        /// <inheritdoc cref="JsonDeserializeException"/>
        /// </summary>
        public JsonDeserializeException(string message, string input, Exception innerException)
            : base(message, innerException)
        {
            Input = input;
        }

        /// <summary>
        /// Input which caused error
        /// </summary>
        public string Input { get; }
    }
}