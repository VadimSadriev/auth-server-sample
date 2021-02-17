using System.Collections.Generic;
using IdentityServer4.Models;

namespace AuthServerEfCore.Web
{
    /// <summary>
    /// Identity configuration for registring auth server clients
    /// </summary>
    public class IdentityConfiguration
    {
        /// <summary>
        /// Api resources
        /// </summary>
        public IList<ApiResource> ApiResources { get; set; }

        /// <summary>
        /// Auth server clients
        /// </summary>
        public IList<Client> Clients { get; set; }
        
        /// <summary>
        /// Api scopes
        /// </summary>
        public IList<ApiScope> ApiScopes { get; set; }
    }
}