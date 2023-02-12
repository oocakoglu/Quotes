using QuotesDemo.Core;
using QuotesDemo.Core.Dto;
using QuotesDemo.Core.Models;
using QuotesDemo.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<LoginResultDto> CheckLogin(string userName, string password)
        {

            User? user = await _unitOfWork.Users.GetUserByUserName(userName);
            if (user == null)
            {
                //**initial
                int userCount = await _unitOfWork.Users.GetCount();
                if (userCount == 0)
                {
                    await _unitOfWork.Users.CreateUser("admin", BCrypt.Net.BCrypt.HashPassword("admin"), true);
                    await _unitOfWork.CommitAsync();
                    return await CheckLogin(userName, password);
                }

                return LoginResultDto.Fail("This user can not find on the system (you can login for test username:admin, passsword:admin)");
            }

            if (user.Active == false)
            {
                return LoginResultDto.Fail("This user not active yet. Please wait system administrator check it (you can login for test username:admin, passsword:admin)");
            }

            bool verified = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (verified == false)
            {
                return LoginResultDto.Fail("Please check your password (you can login for test username:admin, passsword:admin)");
            }

            return LoginResultDto.Success(user.Id, user.UserName);
        }

        public async Task<LoginResultDto> Register(string userName, string password)
        {
            try
            {
                User? user = await _unitOfWork.Users.GetUserByUserName(userName);
                if (user != null)
                {
                    return LoginResultDto.Fail("This username already taken");
                }

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                user = await _unitOfWork.Users.CreateUser(userName, passwordHash, false);
                await _unitOfWork.CommitAsync();
                return LoginResultDto.Success(user.Id, user.UserName);
            }
            catch (Exception ex)
            {
                return LoginResultDto.Fail(ex.Message);
            }

        }
    }
}
