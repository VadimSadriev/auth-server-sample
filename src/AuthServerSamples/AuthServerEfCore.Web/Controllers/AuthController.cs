using System.Threading.Tasks;
using AuthServerEfCore.Web.Models.Login;
using Microsoft.AspNetCore.Mvc;

namespace AuthServerEfCore.Web.Controllers
{
    /// <summary>
    /// Controller for managing authentication
    /// </summary>
    [Route("auth")]
    public class AuthController : Controller
    {
        /// <summary>
        /// Returns login view
        /// </summary>
        [HttpGet("login")]
        public async Task<IActionResult> Login([FromRoute] string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
    }
}