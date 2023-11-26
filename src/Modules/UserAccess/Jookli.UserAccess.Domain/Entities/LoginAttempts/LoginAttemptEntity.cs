using Jookli.BuildingBlocks.Domain;
using Jookli.UserAccess.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Domain.Entities.LoginAttempts
{
    public class LoginAttemptEntity : Entity
    {
        public Guid LoginAttemptId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime SuccessfullAuthorizationDate { get; set; }
        public DateTime BadAuthorizationDate { get; set; }
        public string IpAddress { get; set; }
        public UserEntity User { get; set; }
    }
}
