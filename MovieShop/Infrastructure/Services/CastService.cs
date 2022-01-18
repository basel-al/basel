using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castService;

        public CastService(ICastRepository castService)
        {
            _castService = castService;
        }
        public async Task<CastDetailsResponseModel> GetCastDetails(int id)
        {
            var castDetail = await _castService.GetById(id);

            var castModels = new CastDetailsResponseModel
            {
                Id = castDetail.Id,
                Name = castDetail.Name,
                Gender = castDetail.Gender,
                TmdbUrl = castDetail.TmdbUrl,
                ProfilePath = castDetail.ProfilePath
            };

            foreach (var title in castDetail.MoviesOfCast)
            {
                castModels.MovieTitle.Add(new MovieCardResponseModel { Id = title.MovieId, Title = title.Movie.Title, PosterUrl = title.Movie.PosterUrl });
            }
            return castModels;
        }
    }
}   
