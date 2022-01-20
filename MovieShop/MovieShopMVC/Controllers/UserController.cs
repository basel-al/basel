using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserService _userService;
        private readonly IMovieService _movieService;
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Purchases()
        {
      
            var userId = Convert.ToInt32(HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var x=_userService.GetAllPurchasesForUser(userId);
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            var userId = Convert.ToInt32(HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var x = _userService.GetAllFavoritesForUser(userId);
            return View();
        }
        public Task<IActionResult> Profile()
        {
            return null;

        }
        public Task<IActionResult> EditProfile()
        {
            return null;

        }
       [HttpPost]
        public async Task<IActionResult> BuyForUser(int id)
        {
            var moviedetails = await _movieService.GetMovieDetails(id);
            var request = new PurchaseRequestModel
            { Id = moviedetails.Id,
                TotalPrice = moviedetails.Price.Value,
                PurchaseDateTime = DateTime.Now,
            };

            var x = await _userService.PurchaseMovie(request, id);
            return View();
        }
/*        public async Task<IActionResult> ReviewByUser(PurchaseRequestModel model)
        {
            var x = await _userService.PurchaseMovie.
        }*/
    }
}
