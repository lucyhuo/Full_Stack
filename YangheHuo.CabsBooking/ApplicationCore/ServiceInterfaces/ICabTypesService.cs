using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICabTypesService
    {
        //Task<List<CabTypeResponseModel>> GetAllCabTypes();
        Task<CabBookingsDetailsResponseModel> GetBookingsForCabType(int id);

        // Add 
        Task<int> AddCabType(CabTypeRequestModel request);

        // Update
        Task UpdateCabType(CabTypeRequestModel request);

        // Delete 
        Task DeleteCabType(int id);

        // List All 
        Task<List<CabTypeResponseModel>> GetCabTypesAsync();

    }
}


