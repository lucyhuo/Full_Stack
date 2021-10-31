using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICurrentUserService
    {
        // expose some properties and methods that can be implemented by CurrentUserService class
        // that will read user info from HttpContext 

        public int UserId { get; }
        public bool IsAuthenticated { get;}
        public string FullName { get; }
        //public string Email { get; }
        //public IEnumerable<string> Roles { get; }
        //public bool IsAdmin { get;  }


        Task<List<MovieCardResponseModel>> GetCurrentUserPurchasedMovies(int id);
        Task<List<MovieCardResponseModel>> GetCurrentUserFavoritedMovies(int id);
        Task<List<MovieCardResponseModel>> GetCurrentUserReviewedMovies(int id);
    }
}




