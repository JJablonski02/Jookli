using Jookli.Commander.Application.Configuration.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Application.Features.User.ResetPassword.Command
{
    public class ResetPasswordCommand : InternalCommandBase
    {
        public ResetPasswordCommand(Guid id, Guid userId, string password) : base(id)
        {
            UserId = userId;
            Password = password;
        }

        public Guid UserId { get; set; }
        public string Password { get; set; }    
    }
}
