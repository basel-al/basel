using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var movie = await _movieRepository.GetById(movieId);
            var user = await _userRepository.GetById(userId);
            /*user.Reviews.Where*/

        }

        public async Task<bool> FavoriteExists(int id, int movieId)
        {
            var purchases = await _movieRepository.GetById(movieId);
            throw new NotImplementedException();
        }

        public async Task<FavoriteResponseModel> GetAllFavoritesForUser(int id)
        {
            var myUser = await _userRepository.GetById(id);
            myUser.Favorites.ToList();
            return new FavoriteResponseModel
            {

            };
            throw new NotImplementedException();
        }

        public async Task<PurchaseResponseModel> GetAllPurchasesForUser(int id)
        {
            var purchases = await _purchaseRepository.GetByUserId(id);
            var MyPurchasedMovies = new List<MovieCardResponseModel>();
            foreach (var thepurchase in purchases)
            {
                MyPurchasedMovies.Add(new MovieCardResponseModel { Id = thepurchase.Movie.Id, Title = thepurchase.Movie.Title, PosterUrl = thepurchase.Movie.PosterUrl });
            }
            var myPurchases = new PurchaseResponseModel
            {
                UserId = id,
                TotalMoviesPurchased = purchases.Count,
                PurchasedMovies = MyPurchasedMovies
             };
            return myPurchases;
        }

        public async Task<UserReviewResponseModel> GetAllReviewsByUser(int id)
        {
            var myUser = await _userRepository.GetById(id);
            myUser.Reviews.ToList();
            return new UserReviewResponseModel
            {

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
                PurchaseNumber = purchaseRequest.PurchaseNumber,
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

        public Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }
    }
}

