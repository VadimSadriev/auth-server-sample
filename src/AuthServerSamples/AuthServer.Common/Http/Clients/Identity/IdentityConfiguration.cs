namespace AuthServer.Common.Http.Clients.Identity
{
    /// <summary>
    /// Configuration for identity server
    /// </summary>
    public class IdentityConfiguration
    {
        /// <summary>
        /// Authority
        /// </summary>
        public string Authority { get; set; }

        /// <summary>
        /// Client id 
        /// </summary>
        public string ClientId { get; set; }
        
        /// <summary>
        /// Client secret
        /// </summary>
        public string ClientSecret { get; set; }
        
        /// <summary>
        /// Scope of data client want to retrive via access token
        /// </summary>
        public string Scope { get; set; }
    }
}