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
    }
}