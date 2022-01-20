using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            try
            {
                var user = await _accountService.Register(model);
            }
            catch(Exception ex)
            {
                throw;
            }

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            var user = await _accountService.Validate(model.Email, model.Password);
            if(user ==null)
            {
                return View();
            }
            var claims = new List<Claim> { 
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.DateOfBirth, user.DateOfBirth.ToShortDateString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("language", "english")
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return LocalRedirect("~/");
        }
        public async Task<IActionResult> Logout()
        {
          throw new NotImplementedException();
        }
    }
}
