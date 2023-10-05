﻿using Jookli.Domain.Entities.User;
using Jookli.Domain.Entities.User.RepositoryContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Application.Features.User.Register.Command
{
    public class RegisterCommandHandler : IRequest<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

        public async Task<Unit> Handle(RegisterCommand command)
        {
            var userEmail = _userRepository.GetByUserEmailAsync(command.Email);

            if(userEmail is not null)
            {
                throw new ArgumentException($"User with email: {command.Email} exists");
            }

            var user = new UserEntity()
            {
                UserID = Guid.NewGuid(),
                UserName = command.Username,
                Name = command.Name,
                Surname = command.Surname,
                Email = command.Email,
                Password = command.Password,
                PhoneNumber = command.PhoneNumber,
            };

            await _userRepository.AddUserAsync(user);

            return Unit.Value;
        }
    }
}
