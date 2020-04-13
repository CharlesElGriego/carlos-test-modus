using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
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

        public async Task<User> GetUser(string email)
        {
            return await _repository.GetUser(email);
        }

        public async Task RegisterUserAsync(User user)
        {
            try
            {
               await _repository.RegisterUserAsync(user);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }

           
        }
        #endregion

    }
}