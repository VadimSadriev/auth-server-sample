namespace AuthServerEfCore.Web.Models.Login
{
    /// <summary>
    /// View model for login page
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Return url sent from unathenticated client
        /// </summary>
        public string ReturnUrl { get; set; }
        
        /// <summary>
        /// UserName for login
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// Password for login
        /// </summary>
        public string Password { get; set; }
            
    }
}