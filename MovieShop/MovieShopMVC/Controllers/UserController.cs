using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
            var isLoggedIn = HttpContext.User.Identity.IsAuthenticated;
            if(isLoggedIn)
            {
                var userId = Convert.ToInt32(HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            }
            else
            {
                RedirectToAction("Login", "Account");
            }
            return View();
        }
        public async Task<IActionResult> Favorites()
        {
            var isLoggedIn = HttpContext.User.Identity.IsAuthenticated;
            if (isLoggedIn)
            {
                var userId = Convert.ToInt32(HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            }
            else
            {
                RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
