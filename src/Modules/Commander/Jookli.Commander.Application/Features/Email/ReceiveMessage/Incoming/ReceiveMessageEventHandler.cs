using MediatR;
using Jookli.UserAccess.IntegrationEvents;
using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Application.Features.Email.ReceiveMessage.Command;

namespace Jookli.Commander.Application.Features.Email.ReceiveMessage.Incoming
{
    public class ReceiveMessageEventHandler : INotificationHandler<SendMessageIntegrationEvent>
    {
        private readonly ICommandsScheduler _commandsScheduler;

        public ReceiveMessageEventHandler(ICommandsScheduler commandsScheduler)
        {
            _commandsScheduler = commandsScheduler;
        }
        public async Task Handle(SendMessageIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _commandsScheduler.EnqueueAsync(new ReceiveMessageCommand(
                notification.Id,
                notification.EmailId,
                notification.UserId,
                notification.Message,
                notification.ReceivedDate));
        }
    }
}
