using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopingCart.Application.Core.Services;
using ShopingCart.Domain;
using ShopingCart.Domain.Core.Models;
using ShopingCart.Domain.Entities;
using ShopingCart.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace ShopingCart.Controllers
{
    public class LoginController : Controller, IBaseEntity
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly ILoggerService _logger;
        
        [BindProperty]
        public LoginViewModel LoginModel { get; set; }


        public LoginController(UserManager<Users> userManager, SignInManager<Users> signInManager, ILoggerService logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            ExternalLogins = new List<AuthenticationScheme>();
        }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        //public async Task<IActionResult> LoginAsync(string returnUrl = null)
        //{
        //    returnUrl ??= Url.Content("~/");

        //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

        //    var userName = new EmailAddressAttribute().IsValid(LoginModel.Email) ? new MailAddress(LoginModel.Email).User : LoginModel.Email;

        //    if(ModelState.IsValid)
        //    {
        //        var result = awa
        //    }

        //}


    }
}
