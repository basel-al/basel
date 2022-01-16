
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

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movieDetails = await _movieRepository.GetById(id);
            var movieModel = new MovieDetailsResponseModel
            {
                Id = id,
                Title = movieDetails.Title,
                PosterUrl = movieDetails.PosterUrl,
                BackdropUrl = movieDetails.BackdropUrl,
                ImdbUrl = movieDetails.ImdbUrl,
                Overview =movieDetails.Overview,
                Tagline=movieDetails.Tagline,
                RunTime=movieDetails.RunTime,
                ReleaseDate=movieDetails.ReleaseDate,
                Price= movieDetails.Price,
                Budget = movieDetails.Budget,
                Revenue = movieDetails.Revenue

            };
            foreach(var genre in movieDetails.GenresOfMovie)
            {
                movieModel.Genres.Add(new GenreModel { Id = genre.GenreId, Name = genre.Genre.Name });
            }
            foreach (var trailer in movieDetails.Trailers)
            {
                movieModel.Trailers.Add(new TrailerModel { Id = trailer.Id, Name = trailer.Name, TrailerUrl = trailer.TrailerUrl });
            }
            foreach (var cast in movieDetails.CastsOfMovie)
            {
                movieModel.Casts.Add(new CastModel { Id = cast.CastId, Name = cast.Cast.Name, Character = cast.Character, ProfilePath=cast.Cast.ProfilePath});
            }
/*            foreach (var review in movieDetails.Reviews)
            {
                movieModel.Reviews.Add(new ReviewModel { MovieId = review.MovieId, UserId = review.UserId, Rating = review.Rating, ReviewText = review.ReviewText });
            }*/

            return movieModel;
        }

        public async Task<List<MovieCardResponseModel>> GetTop30GrossingMovies()
        {
            var movies = await _movieRepository.Get30HighestGrossingMovies();
            
            var movieCards = new List<MovieCardResponseModel>(); 
            foreach(var movie in movies)
            {
                movieCards.Add(new MovieCardResponseModel { Id=movie.Id, Title=movie.Title, PosterUrl=movie.PosterUrl });
            }
            return movieCards;
        }
    }
}
