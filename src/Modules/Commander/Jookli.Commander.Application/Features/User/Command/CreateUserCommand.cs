using Jookli.Commander.Application.Configuration.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Application.Features.User.Command
{
    public class CreateUserCommand : InternalCommandBase
    {
        public CreateUserCommand(Guid id, Guid userId, string email, string firstName, string lastName, bool isDeleted) : base(id)
        {
            UserId = userId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            IsDeleted = isDeleted;
        }
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
