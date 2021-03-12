using System;

namespace AuthServer.Common.Http.Exceptions
{
    /// <summary>
    /// Exception thrown during bad/invalid http request
    /// </summary>
    public class ApiException : Exception
    {
        /// <inheritdoc cref="ApiException"/>
        public ApiException()
        {
        }
    }
}