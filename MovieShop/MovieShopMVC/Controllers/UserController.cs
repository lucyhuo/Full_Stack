using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    // all the action methods in User Controller should work only when user is Authenticated (login success)
    public class UserController : Controller
    {
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
        public async Task<IActionResult> Purchases(int id)
        {
            // get all the movies purchased by user => list<MovieCard>
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Favorites(int id)
        {
            // get all movies favorated by that user
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Reviews(int id)
        {
            // get all reviews 
            return View();
        }
    }
}
