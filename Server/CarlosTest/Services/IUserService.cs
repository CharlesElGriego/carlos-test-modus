using CarlosTest.Dtos;
using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosTest.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string email);
        Task RegisterUserAsync(User user);
    }
}
