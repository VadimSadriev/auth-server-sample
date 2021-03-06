﻿using System.Threading.Tasks;
using AuthServerEfCore.Entities;
using AuthServerEfCore.Web.Models.Login;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthServerEfCore.Web.Controllers
{
    /// <summary>
    /// Controller for managing authentication
    /// </summary>
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IIdentityServerInteractionService _interactionService; 

        /// <summary>
        /// <inheritdoc cref="AuthController"/>
        /// </summary>
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, IIdentityServerInteractionService interactionService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interactionService = interactionService;
        }

        /// <summary>
        /// Returns login view
        /// </summary>
        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        
        [HttpGet("logout")]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();

            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);

            if (string.IsNullOrEmpty(logoutRequest.PostLogoutRedirectUri))
            {
                return Redirect("http://localhost:3000");
            }

            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }

        /// <summary>
        /// Logs in user
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, true, false);
           
            if (result.Succeeded)
            {
                return Redirect(vm.ReturnUrl);
            }
            
            return View();
        }
    }
}