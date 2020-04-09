using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataDB.Data;
using DataDB.Models;

namespace DataDB.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Constructor
        public UserRepository()
        {
        }
        #endregion

        #region Public Methods
        public async Task<User> GetUser(string email)
        {
            using (var context = new DataContext())
            {
                return await context.Users.FirstOrDefaultAsync(user => user.Email == email);
            }
        }

        public async Task RegisterUserAsync(User user)
        {
            using (var context = new DataContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
        }
        #endregion


    }
}
