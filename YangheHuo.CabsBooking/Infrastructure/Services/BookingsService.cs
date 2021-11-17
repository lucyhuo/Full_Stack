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
    public class BookingsService : IBookingsService
    {
        private readonly IBookingsRepository _repository;
        public BookingsService(IBookingsRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Add(BookingsRequestModel request)
        {
            var data = new Bookings
            {

                Email = request.Email,
                BookingDate = request.BookingDate,
                BookingTime = request.BookingTime,
                FromPlace = request.FromPlace,
                ToPlace = request.ToPlace,
                PickupAddress = request.PickupAddress,
                Landmark = request.Landmark,
                PickupDate = request.PickupDate,
                PickupTime = request.PickupTime,
                CabTypeId = request.CabTypeId,
                ContactNo = request.ContactNo,
                Status = request.Status
            };

            var newData = await _repository.AddAsync(data);
            return newData.Id;
        }

        public async Task Delete(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
            {
                throw new Exception($"{id} Does Not Exist.");
            }
            await _repository.DeleteAsync(data);
        }

        
        public async Task<List<BookingsResponseModel>> GetAll()
        {
            var data = await _repository.GetAll();

            var dataModel = new List<BookingsResponseModel>();
            foreach (var d in data)
            {
                dataModel.Add(new BookingsResponseModel
                {
                    Email = d.Email,
                    BookingDate = d.BookingDate,
                    BookingTime = d.BookingTime,
                    FromPlace = d.FromPlace,
                    ToPlace = d.ToPlace,
                    PickupAddress = d.PickupAddress,
                    Landmark = d.Landmark,
                    PickupDate = d.PickupDate,
                    PickupTime = d.PickupTime,
                    CabTypeId = d.CabTypeId,
                    ContactNo = d.ContactNo,
                    Status = d.Status
                });

            }
            return dataModel;
        }

        public async Task Update(BookingsRequestModel request)
        {
            var data = new Bookings
            {

                Email = request.Email,
                BookingDate = request.BookingDate,
                BookingTime = request.BookingTime,
                FromPlace = request.FromPlace,
                ToPlace = request.ToPlace,
                PickupAddress = request.PickupAddress,
                Landmark = request.Landmark,
                PickupDate = request.PickupDate,
                PickupTime = request.PickupTime,
                CabTypeId = request.CabTypeId,
                ContactNo = request.ContactNo,
                Status = request.Status
            };
            await _repository.UpdateAsync(data);
        }
    }
}
