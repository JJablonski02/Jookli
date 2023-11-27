using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.Register.Command
{
    public sealed class RegisterCommand : CommandBase
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool PushNotifications { get; set; }
        public bool IsLocationAllowed { get; set; }
        public Gender Gender { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DateOfLastActivity { get; set; }    
    }
}
