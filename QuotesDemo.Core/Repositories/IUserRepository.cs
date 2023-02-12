using QuotesDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Core.Repositories
{
    public interface IUserRepository 
    {
        Task<int> GetCount();

        Task<User?> GetUserByUserName(string userName);

        Task<User> CreateUser(string userName, string password, bool active);


    }
}
