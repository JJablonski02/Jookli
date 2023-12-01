using Jookli.UserAccess.Application.Authentication.Verifycation;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using Jookli.UserAccess.Domain.Entities.UserDetails;
using Jookli.UserAccess.Domain.Entities.UserDetails.Events;
using Jookli.UserAccess.Domain.Entities.UserDetails.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.UserDetails.Add.Command
{
    internal class AddDetailsCommandHandler : ICommandHandler<AddDetailsCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailsRepository _userDetailsRepository;

        public AddDetailsCommandHandler(IUserRepository userRepository, IUserDetailsRepository userDetailsRepository)
        {
            _userRepository = userRepository;
            _userDetailsRepository = userDetailsRepository;
        }

        public async Task<Unit> Handle(AddDetailsCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserIdAsync(command.UserId, cancellationToken);

            if(user == null)
            {
                throw new ArgumentException($"User with {command.UserId} doesn't exists.");
            }

            if (PhoneNumberManager.VerifyPhoneNumber(command.PhoneNumber) == false)
            {
                throw new ArgumentException($"Phone number {command.PhoneNumber} format is incorrect.");
            }

            var userDetails = new UserDetailsEntity
            {
                UserId = user.UserId,
                UserDetailsId = Guid.NewGuid(),
                AreaCode = command.AreaCode,
                PhoneNumber = command.PhoneNumber,
                BaseInfoGender = command.BaseInfoGender,
                DateOfBirth = command.DateOfBirth,
                BaseInfoCountry = command.BaseInfoCountry,
                Education = command.Education,
                Specialization = command.Specialization,
                PlaceOfResidence = command.PlaceOfResidence,
                Legacy = command.Legacy,
                PoliticalViews = command.PoliticalViews,
                CurrentRelationShip = command.CurrentRelationShip,
                Interesets = command.Interesets
            };

            userDetails.AddDomainEvent(new AddUserDetailsDomainEvent(userDetails.UserDetailsId));

            await _userDetailsRepository.AddAsync(userDetails, cancellationToken);

            return Unit.Value;
        }
    }
}
