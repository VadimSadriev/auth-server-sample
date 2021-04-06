using System.Net.Http;
using System.Threading.Tasks;

namespace AuthServer.Common.Http
{
    /// <summary>
    /// Handls authentication http request
    /// </summary>
    public interface IApiAuthenticationHandler
    {
        /// <summary>
        /// Authenticates http request
        /// </summary>
        Task HandleAsync(HttpRequestMessage httpRequestMessage);
    }
}