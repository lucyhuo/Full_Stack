using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IBookingsService
    {
        // Add 
        Task<int> Add(BookingsRequestModel request);

        // Update
        Task Update(BookingsRequestModel request);

        // Delete 
        Task Delete(int id);

        // List All 
        Task<List<BookingsResponseModel>> GetAll();
    }
}
