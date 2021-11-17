﻿using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookingsRepository : EfRepository<Bookings>, IBookingsRepository
    {
        public BookingsRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
