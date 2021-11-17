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
    public class BookingsHistoriesService: IBookingsHistoriesService
    {
        private readonly IBookingsHistoriesRepository _repository;
        public BookingsHistoriesService(IBookingsHistoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Add(BookingHistoriesRequestModel request)
        {
            var data = new BookingsHistories
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
                Status = request.Status,
                Comp_Time = request.Comp_Time,
                Charge = request.Charge,
                Feedback = request.Feedback
    };

            var newData = await _repository.AddAsync(data);
            return newData.Id;
        }

        public async Task Delete(int id)
        {
            var data = await _repository.GetByIdAsync(id);
            if(data == null)
            {
                throw new Exception($"{id} Does Not Exist.");
            }
            await _repository.DeleteAsync(data);

        }

        public async Task<List<BookingHistoriesResponseModel>> GetAll()
        {
            var data = await _repository.GetAll();

            var dataModel = new List<BookingHistoriesResponseModel>();
            foreach (var d in data)
            {
                dataModel.Add(new BookingHistoriesResponseModel
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
                    Status = d.Status,
                    Comp_Time = d.Comp_Time,
                    Charge = d.Charge,
                    Feedback = d.Feedback
                });

            }
            return dataModel;
        }

        public async Task Update(BookingHistoriesRequestModel request)
        {
            var data = new BookingsHistories
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
                Status = request.Status,
                Comp_Time = request.Comp_Time,
                Charge = request.Charge,
                Feedback = request.Feedback
            };
            await _repository.UpdateAsync(data);
        }
    }
}
