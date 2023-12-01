using Jookli.BuildingBlocks.Application.Exceptions;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.UserDetails.Events;
using Jookli.UserAccess.Domain.Entities.UserDetails.Repository;
using MediatR;

namespace Jookli.UserAccess.Application.Features.UserDetails.Update.Command
{
    internal class UpdateDetailsCommandHandler : ICommandHandler<UpdateDetailsCommand>
    {
        private readonly IUserDetailsRepository _userDetailsRepository;
        public UpdateDetailsCommandHandler(IUserDetailsRepository userDetailsRepository)
        {
            _userDetailsRepository = userDetailsRepository;
        }
        public async Task<Unit> Handle(UpdateDetailsCommand command, CancellationToken cancellationToken)
        {
            var user = await _userDetailsRepository.GetByIdAsync(command.UserId);

            if(user == null)
            {
                throw new UserEntityException($"User with email: {command.UserId} does not exists");
            }

            user.AreaCode = command.AreaCode;
            user.BaseInfoGender = command.BaseInfoGender;
            user.DateOfBirth = command.DateOfBirth;
            user.BaseInfoCountry = command.BaseInfoCountry;
            user.Education = command.Education;
            user.Specialization = command.Specialization;
            user.PlaceOfResidence = command.PlaceOfResidence;
            user.Legacy = command.Legacy;
            user.PoliticalViews = command.PoliticalViews;
            user.CurrentRelationShip = command.CurrentRelationShip;
            user.Interesets = command.Interesets;

            user.AddDomainEvent(new UpdateUserDetailsDomainEvent(user.UserDetailsId));

            return Unit.Value;
        }
    }
}
