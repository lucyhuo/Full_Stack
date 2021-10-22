using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using Infrastructure.Services;
using ApplicationCore.ServiceInterfaces;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly int x;
        public HomeController(IMovieService movieService)
        {
            x = 40;
            _movieService = movieService;
        }


        // https://localhost/home/index 
        // Action need to have some attribute, default is HttpGet
        [HttpGet]
        public IActionResult Index()
        {
            // call movie service class to get list of movies card models 
            //MovieService service = new MovieService();

            var movieCards = _movieService.GetTop30RevenueMovies();

            // passing data from controler to view, strongly typed models
            // ViewBag and ViewData 
            //ViewBag.PageTitle = "Top Revenue Movies"; // it's a dynamic type 
            //ViewData["xyz"] = "test data";
            return View(movieCards);
        }

        


        // https://localhost/home/privacy 
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TopMovies()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
