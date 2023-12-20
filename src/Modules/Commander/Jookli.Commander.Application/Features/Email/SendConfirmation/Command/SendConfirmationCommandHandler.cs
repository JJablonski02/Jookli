
using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Domain.Entites.Email;
using Jookli.Commander.Domain.Entites.Email.Events;
using Jookli.Commander.Domain.Entites.Email.Repository;
using Jookli.Commander.Domain.Entites.EmailTemplate.Repository;
using Jookli.Commander.Domain.Entites.User.Repository;
using MediatR;
using System.Net.Http;
using System.Text;

namespace Jookli.Commander.Application.Features.Email.SendConfirmation.Command
{
    internal class SendConfirmationCommandHandler : ICommandHandler<SendConfirmationCommand>
    {
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailRepository _emailRepository;

        public SendConfirmationCommandHandler(IEmailTemplateRepository emailTemplateRepository, IUserRepository userRepository, IEmailRepository emailRepository)
        {
            _emailTemplateRepository = emailTemplateRepository;
            _userRepository = userRepository;
            _emailRepository = emailRepository;
        }
        public async Task<Unit> Handle(SendConfirmationCommand command, CancellationToken cancellationToken)
        {
            var template = await _emailTemplateRepository.GetFullyTemplateByTemplateTypeAsync(Domain.Enums.EmailTemplateType.ConfirmAccount, cancellationToken);

            if(template is null)
            {
                throw new ArgumentException($"Email Template {Domain.Enums.EmailTemplateType.ConfirmAccount} does not exist");
            }

            var user = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

            if(user is null)
            {
                throw new ArgumentException($"User with id {command.UserId} does not exist");
            }

            string content = ContentBuilder(command);

            var email = new EmailEntity
            {
                EmailId = Guid.NewGuid(),
                EmailAccountId = template.EmailAccountId,
                Content = content,
                Subject = template.Subject,
                Receiver = command.Email,
                EmailName = template.EmailName,
                Error = null,
                ProcessedDate = null,
                EmailAttacheds = template.EmailTemplateAttacheds.Select(c => new EmailAttachedEntity
                {
                    EmailAttachedId = c.EmailTemplateAttachedId,
                    FilePath = c.FilePath
                }).ToList()
            };

            email.AddDomainEvent(new SendConfirmationDomainEvent(email.EmailId));

            await _emailRepository.AddAsync(email);

            return Unit.Value;
        }

        private string ContentBuilder(SendConfirmationCommand command)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/html/EmailConfirmationPage.html");
            string body = System.IO.File.ReadAllText(path);

            StringBuilder content = new StringBuilder(body);
            content.Replace("[FirstName]", command.FirstName);
            content.Replace("[LastName]", command.LastName);
            content.Replace("[Link]", command.CallbackUrl);

            return content.ToString();
        }
    }
}
