using System.Collections.Generic;
using IdentityServer4.Models;

namespace AuthServerEfCore.Web
{
    public class IdentityConfiguration
    {
        public IList<ApiResource> ApiResources { get; set; }

        public IList<Client> Clients { get; set; }
    }
}