
using Jookli.Commander.Application.Configuration.Command;
using MediatR;

namespace Jookli.Commander.Application.Features.Email.SendConfirmation.Command
{
    internal class SendConfirmationCommandHandler : ICommandHandler<SendConfirmationCommand>
    {
        public Task<Unit> Handle(SendConfirmationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
