using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    // all the action methods in User Controller should work only when user is Authenticated (login success)
    public class UserController : Controller
    {
        protected readonly ICurrentUserService _currentUserService;
        public UserController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }


        [HttpPost]
        public async Task<IActionResult> Purchase()
        {
            // purchase a movie when user clicks on Buy button on Movie Details page
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Favorite()
        {
            // favorite a movie when user clicks on Favorite Button on Movie Details Page 
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Review()
        {
            // add a new review by the user for that movie
            return View();
        }


        [HttpGet]
        // filters in ASP.NET
        [Authorize] // add role here and do the authorize 
        public async Task<IActionResult> Purchases() //id:12 
        
        {

            //var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userId = _currentUserService.UserId;

            // call userservice that will give list of moviesCard models that this user purchased 
            // purchase repository, dbContext.Purchase.where(u => u.UserId == id) 
            var movieCards = await _currentUserService.GetCurrentUserPurchasedMovies(userId);


            // get all the movies purchased by user => list<MovieCard>

            // get the id from HttpContext.User.Claims
            //var userIdentity = this.User.Identity;
            //if (userIdentity != null && userIdentity.IsAuthenticated)
            //{
            //    // call the database to get the data
            //    return View();
            //}
            //RedirectToAction("Login", "Account");
            return View(movieCards);
        }



        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Favorites(int id)
        {
            // get all movies favorated by that user
            var userId = _currentUserService.UserId;
            var movieCards = await _currentUserService.GetCurrentUserFavoritedMovies(userId);
            return View(movieCards);
        }

        [HttpGet]
        public async Task<IActionResult> Reviews(int id)
        {
            // get all reviews 
            return View();
        }
    }
}
