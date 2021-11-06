using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // create an api method that shows top 30revenue/grossing movies 
        // so that my SPA, iOS, and Android app show those movies in the home screen 
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // http://localhost/api/movies/3
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if(movie == null)
            {
                return NotFound($"No movie found for {id}");
            }
            return Ok(movie);

        }




        // create the api method that shows top 30 movies, json data 

        [HttpGet]
        [Route("toprevenue")]
        // attribute based routing 
        // http://localhose/api/movies/toprevenue
        // API: REST api pattern 
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTop30RevenueMovies();

            // json data and http status code 

            if (!movies.Any())
            {
                // return 404 
                return NotFound("No movies found!");
            }

            return Ok(movies);

            // for converting c# objects to Json objects there are 2 ways 
            // before .Net core 3, Newtonsoft.Json package 
            // now Microsoft create its own JSON Serialization package, System.Text.Json 
        }





    }
}
