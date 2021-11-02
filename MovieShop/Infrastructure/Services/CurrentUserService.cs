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
        protected readonly IPurchaseRepository _purchaseRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
       

        public CurrentUserService(ICurrentUserRepository currentUserRepository, IHttpContextAccessor httpContextAccessor, IPurchaseRepository purchaseRepository)
        {
            _currentUserRepository = currentUserRepository;
            _httpContextAccessor = httpContextAccessor;
            _purchaseRepository = purchaseRepository;
        
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





        //public async Task<List<MovieCardResponseModel>> GetCurrentUserPurchasedMovies(int id)
        //{
            
        //}

        //public async Task<List<MovieCardResponseModel>> GetCurrentUserFavoritedMovies(int id)
        //{

        //    var movies = await _currentUserRepository.GetUserFavoritedMovies(id);
        //    if (movies == null)
        //    {
        //        throw new Exception($"No favorited movie found for this User {id}");
        //    }
        //    var movieCards = new List<MovieCardResponseModel>();
        //    foreach (var movie in movies)
        //    {
        //        movieCards.Add(new MovieCardResponseModel
        //        {
        //            Id = movie.Id,
        //            PosterUrl = movie.PosterUrl,
        //            Title = movie.Title
        //        });
        //    }

        //    return movieCards;
        //}

        //public  Task<List<MovieCardResponseModel>> GetCurrentUserReviewedMovies(int id)
        //{
        //    throw new NotImplementedException();
        //}


        public async Task<PurchaseResponseModel> GetAllPurchasesForUser(int userId)
        {
            var purchases = await _purchaseRepository.GetAllPurchasesForUser(userId);

            if (purchases == null)
            {
                throw new Exception($"No movie has been purchased by this user {userId}");
            }

            var purchasedMovies = new List<MovieCardResponseModel>();
            foreach (var purchase in purchases)
            {
                //var movie = await _movieRepository.GetMovieById(purchase.MovieId);
                var movieCard = new MovieCardResponseModel
                {
                    Id = purchase.MovieId,
                    Title = purchase.MovieDetail.Title,
                    PosterUrl = purchase.MovieDetail.PosterUrl
                };
                purchasedMovies.Add(movieCard);
            }

            var purchaseResponse = new PurchaseResponseModel
            {
                PurchasedMovies = purchasedMovies,
                TotalMoviesPurchased = purchases.Count()

            };

            return purchaseResponse;
        }

        public async Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
        {

            var purchase = new Purchase
            {
                UserId = userId,
                PurchaseNumber = purchaseRequest.PurchaseNumber,
                PurchaseDateTime = purchaseRequest.PurchaseDateTime,
                MovieId = purchaseRequest.MovieId
            };
            var newPurchase = await _purchaseRepository.Add(purchase);
            return newPurchase != null;
    }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            var isPurchased = await _purchaseRepository.GetPurchaseDetails(userId, purchaseRequest.MovieId);
            return isPurchased != null;
        }

        public async Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId)
        {
            var purchaseDetail = await _purchaseRepository.GetPurchaseDetails(userId, movieId);
            var purchaseDetailsResponseModel = new PurchaseDetailsResponseModel
            {
                UserId = userId,
                MovieId = movieId,
                Title = purchaseDetail.MovieDetail.Title,
                PosterUrl = purchaseDetail.MovieDetail.PosterUrl,
                ReleaseDate = purchaseDetail.MovieDetail.ReleaseDate,
                PurchaseDateTime = purchaseDetail.PurchaseDateTime,
                TotalPrice = purchaseDetail.TotalPrice
            };

            return purchaseDetailsResponseModel;

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

        public async Task<ReviewResponseModel> GetAllReviewsByUser(int id)
        {
            throw new NotImplementedException();
        }

    }
}
