using Jookli.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.ResetPassword.Command
{
    public class ResetPasswordCommand : CommandBase
    {
        public ResetPasswordCommand(Guid userId, string token, string password, string replyPassword)
        {
            UserId = userId;
            Token = token;
            Password = password;
            ReplyPassword = replyPassword;
        }

        public Guid UserId { get; set; }
        public string Token { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string ReplyPassword { get; set; }
    }
}
