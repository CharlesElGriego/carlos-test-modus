using CarlosTest.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlosTest.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUser(string email);
        Task RegisterUserAsync(UserDto user);
    }
}
