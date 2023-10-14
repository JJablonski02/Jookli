using Jookli.UserAccess.Application.Contracts;
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
    public class RegisterCommand : CommandBase
    {
        //public RegisterCommand(
        //    string name,
        //    string surname,
        //    string username,
        //    string email,
        //    int phoneNumber,
        //    string password,
        //    string confirmPassword)
        //{
        //    Id = id;
        //    Name = name;
        //    Surname = surname;
        //    Username = username;
        //    Email = email;
        //    PhoneNumber = phoneNumber;
        //    Password = password;
        //    ConfirmPassword = confirmPassword;

        //}
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
