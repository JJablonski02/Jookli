using Jookli.Commander.Application.Configuration.Command;

namespace Jookli.Commander.Application.Features.Email.SendRecoverPassword.Command
{
    public class SendRecoverPasswordCommand : InternalCommandBase
    {
        public SendRecoverPasswordCommand(Guid id, Guid userId, string callbackUrl) : base(id)
        {
            UserId = userId;
            CallbackUrl = callbackUrl;
        }
        public Guid UserId { get; set; }
        public string CallbackUrl { get; set; }
    }
}
