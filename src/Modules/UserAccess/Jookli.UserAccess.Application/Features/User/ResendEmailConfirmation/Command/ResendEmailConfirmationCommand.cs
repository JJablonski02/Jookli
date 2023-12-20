using Jookli.UserAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.ResendEmailConfirmation.Command
{
    public class ResendEmailConfirmationCommand : CommandBase
    {
        public string Email { get; set; }   
    }
}
