using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApplicationCore.Models.FavoriteResponseModel;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private IPurchaseRepository _purchaseRepository;
        private IUserRepository _userRepository;
        private IMovieRepository _movieRepository;
        public UserService(IPurchaseRepository purchaseRepository, IUserRepository userRepository, IMovieRepository movieRepository)
        {
            _purchaseRepository = purchaseRepository;
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }
        public async Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            var newFavorite = new Favorite
            {
                Id = favoriteRequest.Id,
                UserId = favoriteRequest.UserId,
                MovieId = favoriteRequest.MovieId,
            };
            var user = await _userRepository.GetById(favoriteRequest.UserId);
            user.Favorites.Add(newFavorite);
        }
        public async Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            var newReview = new Review
            {
                MovieId = reviewRequest.MovieId,
                UserId = reviewRequest.UserId,
                Rating = reviewRequest.Rating,
                ReviewText = reviewRequest.ReviewText,
            };
            var movie = await _movieRepository.GetById(reviewRequest.MovieId);
            movie.Reviews.Add(newReview);
        }

        public async Task DeleteMovieReview(int userId, int movieId)
        {
            var movies = await _movieRepository.GetById(movieId);
            var reviewedMovie = movies.Reviews.Where(x => x.UserId == userId);
            reviewedMovie.ToList().RemoveAt(0);

        }

        public async Task<bool> FavoriteExists(int id, int movieId)
        {
            var purchases = await _movieRepository.GetById(movieId);
            throw new NotImplementedException();
        }

        public async Task<FavoriteResponseModel> GetAllFavoritesForUser(int id)
        {
            var favs = await _userRepository.GetFavoritesOfUser(id);

            var favoriteresponse = new FavoriteResponseModel();
            foreach (var fav in favs)
            {
                favoriteresponse.UserId = id;
                favoriteresponse.FavoriteMovies.Add(new FavoriteMovieResponseModel { Id = fav.MovieId, Title = fav.Movie.Title, PosterUrl = fav.Movie.PosterUrl, ReleaseDate = fav.Movie.ReleaseDate.Value });
            }
            return favoriteresponse;
        }

        public async Task<PurchaseResponseModel> GetAllPurchasesForUser(int id)
        {
            var mypurchases = await _purchaseRepository.GetPurchasesOfUser(id);
            var purchaseresponse = new PurchaseResponseModel();
            purchaseresponse.UserId = id;
            foreach (var thepurchase in mypurchases)
            {
                purchaseresponse.PurchasedMovies.Add(new MovieCardResponseModel { Id = thepurchase.Movie.Id, Title = thepurchase.Movie.Title, PosterUrl = thepurchase.Movie.PosterUrl });
            }
            return purchaseresponse;
        }

        public async Task<UserReviewResponseModel> GetAllReviewsByUser(int id)
        {
            var myUser = await _userRepository.GetById(id);
            /*var reviewlist = myUser.Reviews.ToList();*/
            var reviewlist = myUser.Reviews;
            var MovieReviewsList = new List <MovieReviewResponseModel>();
            foreach (var review in reviewlist)
            {
                MovieReviewsList.Add(new MovieReviewResponseModel { UserId = review.UserId, MovieId = review.MovieId, ReviewText = review.ReviewText, Rating = review.Rating , Name= review.Movie.Title});
            }
            return new UserReviewResponseModel
            {
                UserId=id,
                MovieReviews= MovieReviewsList
            };
        }

        public async Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId)
        {
            var purchases = await _purchaseRepository.GetAll();
            foreach (var purchase in purchases)
            {
                if (purchase.UserId == userId && purchase.MovieId == movieId)
                {
                    return new PurchaseDetailsResponseModel
                    {
                        Id = purchase.Id,
                        UserId = purchase.UserId,
                        PurchaseNumber = purchase.PurchaseNumber,
                        TotalPrice = purchase.TotalPrice,
                        PurchaseDateTime = purchase.PurchaseDateTime,
                        MovieId = purchase.MovieId,
                        Title = purchase.Movie.Title,
                        PosterUrl = purchase.Movie.PosterUrl,
                        ReleaseDate = purchase.Movie.ReleaseDate.GetValueOrDefault(),
                    };
                }
            }
            throw new Exception("error");


        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            var y = await _purchaseRepository.GetPurchasesOfUser(userId);
            foreach(var t in y)
            {
                
                t.Id = purchaseRequest.Id;
                t.UserId = userId;
                t.PurchaseNumber = purchaseRequest.PurchaseNumber;
                t.TotalPrice = purchaseRequest.TotalPrice;
                t.PurchaseDateTime = purchaseRequest.PurchaseDateTime;
                t.MovieId = purchaseRequest.MovieId;
            }
            var purchases = await _purchaseRepository.GetByUserId(userId);
            foreach (var purchase in purchases)
            {
                if (purchase.MovieId == purchaseRequest.MovieId)
                {
                    return true;
                }
            }
            return false;

        }

        public async Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
        {           
            var newPurchase = new Purchase
            {      
                Id = purchaseRequest.Id,
                UserId = userId,
               /*PurchaseNumber = purchaseRequest.PurchaseNumber,*/
                TotalPrice = purchaseRequest.TotalPrice,
                PurchaseDateTime = purchaseRequest.PurchaseDateTime,
            };
            var dbCreatedPurchase = await _purchaseRepository.Add(newPurchase);
            if (dbCreatedPurchase.Id > 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

       public async Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            /*            var movies = await _userRepository.Delete
                        var favoritedMovie = movies.Favorite.Where(x => x.UserId == favoriteRequest.UserId);
                        favoritedMovie.ToList().RemoveAt(0);*/
            throw new NotImplementedException();
            
        }

        public async Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            var movies = await _movieRepository.GetById(reviewRequest.MovieId);
            var favoritedMovie = movies.Favorite.Where(x => x.UserId == reviewRequest.UserId);
            var x = new Review
            {
                MovieId = reviewRequest.MovieId,
                UserId = reviewRequest.UserId,
                Rating = reviewRequest.Rating,
                ReviewText = reviewRequest.ReviewText,
            };
            favoritedMovie.ToList().RemoveAt(0);
        }
    }
}

