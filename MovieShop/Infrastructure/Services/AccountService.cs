using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Register(UserRegisterRequestModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user != null)
            {
                throw new Exception("Email already exists, login again");
            }
            var salt = GetRandomSalt();
            var hashedPassword = GetHashedPassword(model.Password, salt);

            var newUser = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Salt = salt,
                HashedPassword = hashedPassword,
            };
            var dbCreatedUser = await _userRepository.Add(newUser);
            if (dbCreatedUser.Id > 1)
            {
                return true;
            }
            return false;
        }

        public async Task<UserLoginResponseModel> Validate(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("Email does not exist");
            }
            var hashedPassword = GetHashedPassword(password, user.Salt);
            if (hashedPassword == user.HashedPassword)
            {
                var dbUser = new UserLoginResponseModel
                {
                    Id = user.Id,
                    Email = email,
                    DateOfBirth = user.DateOfBirth.GetValueOrDefault(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                };
                return dbUser;

            }
            return null;
        }

        private string GetRandomSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = RandomNumberGenerator.Create())
            {
                rngCsp.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);

        }
        private string GetHashedPassword(string password, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Convert.FromBase64String(salt),
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            return hashed;

        }
    }
}

