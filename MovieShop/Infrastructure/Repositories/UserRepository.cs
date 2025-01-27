﻿using ApplicationCore.Entities;
using ApplicationCore.Models;
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
    public class UserRepository: EfRepository<User>, IUserRepository
    {
        //private readonly MovieShopDbContext _dbContext;
        public UserRepository(MovieShopDbContext dbContext): base(dbContext)
        {
            //_dbContext = dbContext;
        }

        //public async Task<User> AddUser(User user)
        //{
        //    await _dbContext.Users.AddAsync(user);
        //    await _dbContext.SaveChangesAsync();
        //    return user;
        //}

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }


        public async Task<IEnumerable<Review>> GetReviewsByUser(int userId)
        {
            throw new System.NotImplementedException();
        }

    }
}
