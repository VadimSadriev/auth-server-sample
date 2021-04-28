using System.Threading.Tasks;

namespace AuthServer.Common.Http.Clients.Identity
{
    /// <summary>
    /// Api client for requesting identity server
    /// </summary>
    public interface IIdentityApiClient : IApiClient
    {
        /// <summary>
        /// Returns access token for <paramref name="scope"/>
        /// </summary>
        Task<string> GetAccessTokenAsync();
    }
}