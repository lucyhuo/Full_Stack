using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IPlacesService
    {
        // Add 
        Task<int> Add(PlaceRequestModel request);

        // Update
        Task Update(PlaceRequestModel request);

        // Delete 
        Task Delete(int id);

        // List All 
        Task<List<PlaceResponseModel>> GetAll();
    }
}
