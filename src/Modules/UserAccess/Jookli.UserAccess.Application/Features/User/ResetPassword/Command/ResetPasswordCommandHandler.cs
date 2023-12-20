using Jookli.BuildingBlocks.Application.Exceptions;
using Jookli.UserAccess.Application.Authentication;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.User.Events;
using Jookli.UserAccess.Domain.Entities.User.RepositoryContract;
using MediatR;


namespace Jookli.UserAccess.Application.Features.User.ResetPassword.Command
{
    public class ResetPasswordCommandHandler :ICommandHandler<ResetPasswordCommand>
    {
        private readonly IUserRepository _userRepository;
        public ResetPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(ResetPasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserIdAsync(command.UserId, cancellationToken);

            if (user == null)
            {
                throw new UserEntityException($"User with email: {command.UserId} does not exist");
            }

            if(user.Password != command.ReplyPassword)
            {
                throw new UserEntityException($"Passwords mus be the same");
            }

            var password = PasswordManager.HashPassword(command.Password);
            user.Password = password;
            user.DateOfLastActivity = DateTime.UtcNow;

            user.AddDomainEvent(new UserPasswordChangedDomainEvent (user.UserId, password));

            return Unit.Value;
        }
    }
}
