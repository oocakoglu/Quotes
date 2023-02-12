using Microsoft.EntityFrameworkCore;
using QuotesDemo.Core.Models;
using QuotesDemo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Data.Repositories
{
    public class UserRepository :  IUserRepository
    {
        protected readonly QuoteDbContext _myContext;

        public UserRepository(QuoteDbContext context)
        {
            this._myContext = context;
        }

        public async Task<int> GetCount()
        {
            return await _myContext.Users.CountAsync();
        }

        public async Task<User?> GetUserByUserName(string userName)
        {
            return await _myContext.Users.Where(q => q.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<User> CreateUser(string userName, string password, bool active)
        {
            User user = new User();
            user.UserName = userName;
            user.Password = password;
            user.Active = active;
            await _myContext.Users.AddAsync(user);
            return user;
        }


    }
}
