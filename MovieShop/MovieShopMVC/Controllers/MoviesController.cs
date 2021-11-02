using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // localhost:2345/movies/details/343
        [HttpGet]
        public async Task<IActionResult> Details(int movieId)
        {
            
            var movieDetails = await _movieService.GetMovieDetails(movieId);
            return View(movieDetails);
        }
    }
}
