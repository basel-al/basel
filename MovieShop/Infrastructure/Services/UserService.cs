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
        public UserService(IPurchaseRepository purchaseRepository, IUserRepository userRepository)
        {
            _purchaseRepository = purchaseRepository;
            _userRepository = userRepository;
        }
        public Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new NotImplementedException();
        }

        public Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new NotImplementedException();
        }
        
        public Task DeleteMovieReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FavoriteExists(int id, int movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<FavoriteResponseModel> GetAllFavoritesForUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PurchaseResponseModel>> GetAllPurchasesForUser(int id)
        {
            var purchases = await _purchaseRepository.GetByUserId(id);
            var myPurchases = new List<PurchaseResponseModel>();
            foreach (var purchase in purchases)
            {
                    myPurchases.Add(new PurchaseResponseModel { Id = purchase.Id, UserId = purchase.UserId, PurchaseNumber = purchase.PurchaseNumber });

            }
            return myPurchases;
        }

        public async Task<UserReviewResponseModel> GetAllReviewsByUser(int id)
        {
            /*var userDetails = await _userRepository.GetById(id);
            *//*            var userModel = new UserLoginResponseModel
                        {
                            Id = id,
                            FirstName = userDetails.FirstName,
                            LastName = userDetails.LastName,
                            Email = userDetails.Email,
                            DateOfBirth = userDetails.DateOfBirth

                        };*//*

            var userModel = new UserReviewResponseModel
            {
                UserId = id,
                MovieId = userDetails.Reviews,
            };
*//*            {
                foreach(var reviews in userDetails.Reviews)
                {

                }
                MovieId = userDetails.Reviews.MovieId,
                UserId = id,

            };*//*


            foreach (var reviews in userDetails.Reviews)
            {
                userModel.Reviews.Add(new UserReviewResponseModel { MovieId = reviews.MovieId, UserId = reviews.UserId, Rating = reviews.Rating, ReviewText = reviews.ReviewText });
            }
            return userModel.Reviews;*/

            throw new NotImplementedException();
        }

        public async Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId)
        {
            //var purchaseDetails = await _purchaseRepository
                throw new NotImplementedException();
        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            var purchases = await _purchaseRepository.GetByUserId(userId);
            foreach(var purchase in purchases)
            {
                if(purchase.MovieId == purchaseRequest.MovieId)
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
