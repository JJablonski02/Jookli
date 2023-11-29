using Jookli.Payments.Application.Configuration.Command;
using Jookli.Payments.Application.Features.User.Command;
using Jookli.UserAccess.IntegrationEvents;
using MediatR;

namespace Jookli.Payments.Application.Features.User.Incoming
{
    internal class CreateUserEventHandler : INotificationHandler<NewUserRegisteredIntegrationEvent>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        public CreateUserEventHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }

        public async Task Handle(NewUserRegisteredIntegrationEvent notification, CancellationToken cancellationToken)
        {

            await _commandsScheduler.EnqueueAsync(
                new CreateUserCommand(
                    notification.Id,
                    notification.UserId,
                    notification.Email,
                    notification.FirstName,
                    notification.LastName,
                    notification.IsDeleted
                    ));

        }
    }
}
