using QuotesDemo.Core.Dto;
using QuotesDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Core.Services
{
    public interface IUserService
    {
        Task<LoginResultDto> CheckLogin(string userName, string password);

        Task<LoginResultDto> Register(string userName, string password);
    }
}
