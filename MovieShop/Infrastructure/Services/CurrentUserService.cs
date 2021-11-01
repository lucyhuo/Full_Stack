using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        protected readonly ICurrentUserRepository _currentUserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(ICurrentUserRepository currentUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            _currentUserRepository = currentUserRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        // we need to use HttpContext class to get all this information from HttpContext User Object

        public int UserId => Convert.ToInt32((_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value));

        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User.Identity != null &&
            _httpContextAccessor.HttpContext != null &&
            _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public string FullName => _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value
                                  + " " + _httpContextAccessor.HttpContext?.User.Claims
                                      .FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;


        //public string Email => _httpContextAccessor.HttpContext?.User.Claims
        //    .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        //public IEnumerable<string> Roles { get; set; }
        //public bool IsAdmin { get; set; }





        public async Task<List<MovieCardResponseModel>> GetCurrentUserPurchasedMovies(int id)
        {
            var movies = await _currentUserRepository.GetUserPurchasedMovies(id);
            if (movies == null)
            {
                throw new Exception($"No favorited movie found for this User {id}");
            }
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title
                });
            }

            return movieCards;
        }

        public async Task<List<MovieCardResponseModel>> GetCurrentUserFavoritedMovies(int id)
        {

            var movies = await _currentUserRepository.GetUserFavoritedMovies(id);
            if (movies == null)
            {
                throw new Exception($"No favorited movie found for this User {id}");
            }
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title
                });
            }

            return movieCards;
        }

        public  Task<List<MovieCardResponseModel>> GetCurrentUserReviewedMovies(int id)
        {
            throw new NotImplementedException();
        }



        public async Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<FavoriteResponseModel> GetAllFavoritesForUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<PurchaseResponseModel> GetAllPurchasesForUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteMovieReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserReviewResponseModel> GetAllReviewsByUser(int id)
        {
            throw new NotImplementedException();
        }

    }
}
