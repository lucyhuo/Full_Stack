using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface ICabTypesRepository : IAsyncRepository<CabTypes>
    {
        //Task<IEnumerable<CabTypes>> GetAllCabTypes();
        Task<CabTypes> GetBookingsForCabType(int id);
    }
}
