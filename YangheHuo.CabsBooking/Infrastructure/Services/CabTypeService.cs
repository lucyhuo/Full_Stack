using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CabTypeService : ICabTypesService
    {
        private readonly ICabTypesRepository _cabTypesRepository;
        public CabTypeService(ICabTypesRepository cabTypesRepository)
        {
            _cabTypesRepository = cabTypesRepository;
        }

        // get bookings details for a given cab type id
        public async Task<CabBookingsDetailsResponseModel> GetBookingsForCabType(int id)
        {
            var cabType = await _cabTypesRepository.GetBookingsForCabType(id);
            var cabBookingsDetails = new CabBookingsDetailsResponseModel()
            {
                Id = cabType.CabTypeId,
                Name = cabType.CabTypeName
            };
            cabBookingsDetails.Bookings = new List<BookingsModel>();
            foreach (var booking in cabType.Bookings)
            {
                cabBookingsDetails.Bookings.Add(new BookingsModel
                {
                    Id = booking.Id,
                    Email = booking.Email,
                    BookingDate = booking.BookingDate,
                    BookingTime = booking.BookingTime,
                    FromPlace = booking.FromPlace,
                    ToPlace = booking.ToPlace,
                    PickupAddress = booking.PickupAddress,
                    Landmark = booking.Landmark,
                    PickupDate = booking.PickupDate,
                    PickupTime = booking.PickupTime,
                    CabTypeId = booking.CabTypeId,
                    ContactNo = booking.ContactNo,
                    Status = booking.Status
                });
            }
            return cabBookingsDetails;
        }

        // list all cab types 
        public async Task<List<CabTypeResponseModel>> GetCabTypesAsync()
        {
            var data = await _cabTypesRepository.GetAll();

            var dataModel = new List<CabTypeResponseModel>();
            foreach (var d in data)
            {
                dataModel.Add(new CabTypeResponseModel
                {
                    CabTypeId = d.CabTypeId,
                    CabTypeName = d.CabTypeName
                });

            }
            return dataModel;
        }
        
        // add a cab type 
        public async Task<int> AddCabType(CabTypeRequestModel request)
        {

            // create cab type entity 
            var cab = new CabTypes
            {

                CabTypeName = request.CabTypeName
            };

            var newCabType = await _cabTypesRepository.AddAsync(cab);
            return newCabType.CabTypeId;
        }

        // delete a cab type by id
        public async Task DeleteCabType(int id)
        {
            var data = await _cabTypesRepository.GetByIdAsync(id);
            if (data == null)
            {
                throw new Exception($"{id} Does Not Exist.");
            }
            await _cabTypesRepository.DeleteAsync(data);

        }

        // update cab type by id 
        public async Task UpdateCabType(CabTypeRequestModel request)
        {
            var cab = new CabTypes
            {
                CabTypeId = request.CabTypeId,
                CabTypeName = request.CabTypeName
            };
            await _cabTypesRepository.UpdateAsync(cab);
        }
    }
}
