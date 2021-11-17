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
    public class PlaceService : IPlacesService
    {
        private readonly IPlacesRepository _repository;
        public PlaceService(IPlacesRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Add(PlaceRequestModel request)
        {
            var data = new Places
            {

                PlaceName = request.PlaceName
            };

            var newData = await _repository.AddAsync(data);
            return newData.PlaceId;
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

        public async Task<List<PlaceResponseModel>> GetAll()
        {
            var data = await _repository.GetAll();

            var dataModel = new List<PlaceResponseModel>();
            foreach (var d in data)
            {
                dataModel.Add(new PlaceResponseModel
                {
                    PlaceId = d.PlaceId,
                    PlaceName = d.PlaceName
                });

            }
            return dataModel;
        }

        public async Task Update(PlaceRequestModel request)
        {
            var data = new Places
            {
                PlaceId = request.PlaceId,
                PlaceName = request.PlaceName
            };
            await _repository.UpdateAsync(data);
        }
    }
}
