using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Authentication.Authenticate
{
    public class AuthenticationResult
    {
        public AuthenticationResult(string authenticationError)
        {
            IsAuthenticated = false;

        }

        public bool IsAuthenticated { get; }
        public string AuthenticationError { get; }
        public UserDTO User { get; }
    }
}
