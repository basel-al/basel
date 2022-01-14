using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> GetTop30GrossingMovies();
        Task<MovieDetailsResponseModel> GetMovieDetails(int id);
    }
}
