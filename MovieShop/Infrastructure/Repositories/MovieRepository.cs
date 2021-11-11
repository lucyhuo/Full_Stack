using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie> , IMovieRepository
    {
        //public MovieShopDbContext _dbContext;
        //public MovieRepository(MovieShopDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public MovieRepository(MovieShopDbContext dbContext): base(dbContext)
        {

        }

        public async Task<IEnumerable<Movie>> GetTop30RatedMovies()
        {
            // going to review table 
            // movieId, title, posterUrl, rating => 

            var movies = await _dbContext.Reviews.Include(r => r.Movie)
                .GroupBy(r => new { Id = r.MovieId, r.Movie.PosterUrl })
                .OrderByDescending(g => g.Average(m => m.Rating))
                .Select(m =>
                    new Movie
                    {
                        Id = m.Key.Id,
                        PosterUrl = m.Key.PosterUrl,
                        Rating = m.Average(x => x.Rating)
                    }).Take(30).ToListAsync();
            return movies;
        }


        public async Task<IEnumerable<Movie>> GetTop30RevenueMovies()
        {
            // we are gonna use EF with LINQ to get top 30 movies by revenue 
            // SQL select top 30 * from movies order by revenue 

            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();

            return movies;

        }
        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.GenresForMovie).ThenInclude(m => m.Genre)
                .Include(m => m.CastsForMovie).ThenInclude(m => m.Cast).Include(m => m.Trailers)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null) throw new Exception("Movie Not found");

            var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty()
                .AverageAsync(r => r == null ? 0 : r.Rating);
            if (movieRating > 0) movie.Rating = movieRating;

            return movie;
        }
        public async Task<IEnumerable<Review>> GetMovieReviews(int id, int pageSize = 30, int page = 1)
        {
            throw new NotImplementedException();
        }
    }
}