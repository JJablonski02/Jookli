using Jookli.Games.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Application.Features.Profile.Command
{
    public class ProfileCommand : CommandBase
    {
        public Guid ProfileId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DateOfLastActivity { get; set; }
    }
}
