using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Authentication.Authenticate
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public List<Claim> Claims { get; set; }
        public bool IsAccountBlocked { get; set; }
        public DateTime? AccountBlockedSince { get; set; }
        public DateTime? AccountBlockedUntil { get; set; }
    }
}
