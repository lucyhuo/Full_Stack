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
    public class CabTypesRepository : EfRepository<CabTypes>, ICabTypesRepository
    {
        public CabTypesRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {

        }

        //public async Task<IEnumerable<CabTypes>> GetAllCabTypes()
        //{
        //    var data = await _dbContext.CabTypes.OrderByDescending(m => m.CabTypeId).ToListAsync();
        //    return data;
        //}

        public async Task<CabTypes> GetBookingsForCabType(int id)
        {
            var data = await _dbContext.CabTypes.Include(c => c.Bookings)
                .FirstOrDefaultAsync(c => c.CabTypeId == id); 
            if(data == null)
            {
                throw new Exception($"No Record Found With CabTypeId {id}");
            }
            return data;
        }
    }
}
