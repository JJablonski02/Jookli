using Jookli.BuildingBlocks.Application.Exceptions;
using Jookli.UserAccess.Application.Configuration.Command;
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
                throw new UserEntityException($"User with email: {command.UserId} does not exists");
            }

            if(user.Password != command.OldPassword)
            {
                throw new UserEntityException($"Wrong old Password");
            }

            user.Password = command.Password;
            user.DateOfLastActivity = DateTime.UtcNow;

            return Unit.Value;
        }
    }
}
