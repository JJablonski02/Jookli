using Jookli.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.Login.Command
{
    public class LoginCommand : CommandBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
