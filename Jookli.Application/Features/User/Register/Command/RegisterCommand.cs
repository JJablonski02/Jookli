using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Application.Features.User.Register.Command
{
    public record RegisterCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage =("Password and Confirm password must match"))]
        public string ConfirmPassword { get; set; }
    }
}
