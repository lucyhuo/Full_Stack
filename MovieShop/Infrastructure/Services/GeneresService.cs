using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;


namespace Infrastructure.Services
{
    public class GeneresService : IGenresService
    {
        private readonly IGenresRepository  _genresRepository; // readonly: you cannot this, unless you change it in the constructor
        public GeneresService(IGenresRepository genresRepository)
        {
            _genresRepository = genresRepository;
        }


        public async Task<List<GenreModel>> GetGenres()
        {
            var genres = await _genresRepository.GetAll();

            var genresModel = new List<GenreModel>();
            foreach (var genre in genres)
            {
                genresModel.Add(new GenreModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });

            }
            return genresModel;
        } 
    }
}


