using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CurrentUserRepository : ICurrentUserRepository
    {
        public MovieShopDbContext _dbContext;
        public CurrentUserRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Movie>> GetUserFavoritedMovies(int id)
        {
            var favorites = await _dbContext.Favorites.Where(p => p.UserId == id).ToListAsync();
            List<Movie> movies = new List<Movie>();
            foreach (var favorite in favorites)
            {
                var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == favorite.MovieId);
                movies.Add(movie);
            }
            return movies;
        }

        public async Task<IEnumerable<Movie>> GetUserPurchasedMovies(int id)
        {

            var purchases = await _dbContext.Purchases.Where(p => p.UserId == id).ToListAsync();
            List<Movie> movies = new List<Movie>();
            foreach (var purchase in purchases)
            {
                var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == purchase.MovieId);
                movies.Add(movie);
            }
            return movies;
        }

        public async Task<IEnumerable<Movie>> GetUserReviewdMovies(int id)
        {
            throw new NotImplementedException();
        }
    }
}
