
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;


namespace Infrastructure.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public List<MovieCardResponseModel> GetTop30GrossingMovies()
        {
            var movies = _movieRepository.Get30HighestGrossingMovies();
            
            var movieCards = new List<MovieCardResponseModel>(); 
            foreach(var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel { Id=movie.Id, Title=movie.Title, PosterUrl=movie.PosterUrl });
            }
            return movieCards;
        }
    }
}
