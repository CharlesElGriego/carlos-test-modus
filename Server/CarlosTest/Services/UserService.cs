using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CarlosTest.Dtos;
using DataDB.Models;
using DataDB.Repositories;

namespace CarlosTest.Services
{
    public class UserService : IUserService
    {
        #region Private Properties
        private readonly IUserRepository _repository;
        #endregion

        #region Constructor
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Public Methods

        public async Task<UserDto> GetUser(string email)
        {
            var user = await _repository.GetUser(email);
            if (user == null)
            {
                return null;
            }
            return new UserDto
            {
                Email = user.Email,
                FullName = user.Name,
                Type = user.Type,
                UserPassword = user.Password
            };
        }

        public async Task RegisterUserAsync(UserDto user)
        {
            User newUser = new User
            {
                Email = user.Email,
                Name = user.FullName,
                Type = user.Type,
                Password = user.UserPassword
            };

            try
            {
               await _repository.RegisterUserAsync(newUser);
            }
            catch (Exception)
            {
                throw new Exception("User already exists");
            }

           
        }
        #endregion

    }
}