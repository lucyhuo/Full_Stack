﻿using ApplicationCore.Entities;
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
    public class MovieRepository : IMovieRepository
    {
        public MovieShopDbContext _dbContext;
        public MovieRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.GenresForMovie).ThenInclude(m => m.Genre)
                .Include(m => m.CastsForMovie).ThenInclude(m => m.Cast).Include(m => m.Trailers)
                .FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        }


        public async Task<IEnumerable<Movie>> GetTop30RevenueMovies()
        {
            // we are gonna use EF with LINQ to get top 30 movies by revenue 
            // SQL select top 30 * from movies order by revenue 

            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;

        }
    }
}