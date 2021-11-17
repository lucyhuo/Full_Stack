using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationCore.ServiceInterfaces
{
    public interface IBookingsHistoriesService
    {
        // Add 
        Task<int> Add(BookingHistoriesRequestModel request);

        // Update
        Task Update(BookingHistoriesRequestModel request);

        // Delete 
        Task Delete(int id);

        // List All 
        Task<List<BookingHistoriesResponseModel>> GetAll();
    }
}
