using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Core.Dto
{
    public class LoginResultDto
    {
        public bool Status { get; set; }

        public string Message { get; set; } = null!;

        public int UserId { get; set; } = 0;

        public string UserName { get; set; } = null!;

        public static LoginResultDto Success(int userId, string userName)
        {
            return new LoginResultDto { Status = true, Message = "Success", UserId = userId, UserName = userName };
        }

        public static LoginResultDto Fail(string message)
        {
            return new LoginResultDto { Status = false, Message = message, UserId=0, UserName = "" };
        }
    }
}
