using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieShop.UnitTests
{
    [TestClass]
    public class MovieSeriviceUnitTest
    {
        private MovieService _sut;
        private static List<Movie> _movies;
        private Mock<IMovieRepository> _mockMovieRepository;

        [TestInitialize]
        //[OnneTimeSetup] in NUnit
        public void OnTimeSetup()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();

            // for this movie service, injecting a class that is implmemting the interface IMovieRepository
            _sut = new MovieService(_mockMovieRepository.Object);

            _mockMovieRepository.Setup(m => m.GetTop30RevenueMovies()).ReturnsAsync(_movies);

        }

        [ClassInitialize]
        public static void Setup( TestContext context)
        {

            _movies = new List<Movie>
            {
                new Movie{Id=1, Title = "Avengers: Infinity War", Budget = 1200000},
                new Movie{Id=2, Title = "Avartar", Budget = 1200000},
                new Movie{Id=3, Title = "Star Wars: The Force Awakens", Budget = 1200000},
                new Movie{Id=4, Title = "Titanic", Budget = 1200000},
                new Movie{Id=5, Title = "Inception", Budget = 1200000},
                new Movie{Id=6, Title = "Avengers: Age of Ultron", Budget = 1200000}
            };
        }



        [TestMethod]
        public async Task TestListOfTopRevenueMoviesFromFakeData()
        {
            // SUT system unders test: MovieService => GetTopRevenueMovies

            // Arrange 
            // mock objects, data, methods etc
            //_sut = new MovieService(new MockMovieRepository());



            // Act
            var movies = await _sut.GetTop30RevenueMovies();
            // check the actual output with expected data
            // pattern: AAA 
            // Arrange, Act, and Assert

            // Assert
            Assert.IsNotNull(movies);
            Assert.IsInstanceOfType(movies, typeof(IEnumerable<MovieCardResponseModel> ));
            
            Assert.AreEqual(6, movies.Count);
        }
    }

    //public class MockMovieRepository : IMovieRepository
    //{
    //    public Task<Movie> Add(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task Delete(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<IEnumerable<Movie>> GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<IEnumerable<Movie>> GetByCondition(Expression<Func<Movie, bool>> predicate)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<Movie> GetById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<int> GetCount(Expression<Func<Movie, bool>> predicate)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<Movie> GetMovieById(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<IEnumerable<Review>> GetMovieReviews(int id, int pageSize = 30, int page = 1)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public async Task<IEnumerable<Movie>> GetTop30RevenueMovies()
    //    {
    //        var _movies = new List<Movie>
    //        {
    //            new Movie{Id=1, Title = "Avengers: Infinity War", Budget = 1200000},
    //            new Movie{Id=2, Title = "Avartar", Budget = 1200000},
    //            new Movie{Id=3, Title = "Star Wars: The Force Awakens", Budget = 1200000},
    //            new Movie{Id=4, Title = "Titanic", Budget = 1200000},
    //            new Movie{Id=5, Title = "Inception", Budget = 1200000},
    //            new Movie{Id=6, Title = "Avengers: Age of Ultron", Budget = 1200000}

    //        };
    //        return _movies;
    //    }

    //    public Task<Movie> Update(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
