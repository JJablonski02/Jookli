using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Application.Features.Email.SendConfirmation.Command;
using Jookli.Commander.Domain.Entites.Email;
using Jookli.Commander.Domain.Entites.Email.Events;
using Jookli.Commander.Domain.Entites.Email.Repository;
using Jookli.Commander.Domain.Entites.EmailTemplate.Repository;
using Jookli.Commander.Domain.Entites.User;
using Jookli.Commander.Domain.Entites.User.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Jookli.Commander.Application.Features.Email.SendRecoverPassword.Command
{
    public class SendRecoverPasswordCommandHandler : ICommandHandler<SendRecoverPasswordCommand>
    {
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly IEmailRepository _emailRepository;
        private readonly IUserRepository _userRepository;
        public SendRecoverPasswordCommandHandler(IEmailTemplateRepository emailTemplateRepository, IEmailRepository emailRepository, IUserRepository userRepository)
        {
            _emailTemplateRepository = emailTemplateRepository;
            _emailRepository = emailRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(SendRecoverPasswordCommand command, CancellationToken cancellationToken)
        {
            var template = await _emailTemplateRepository.GetFullyTemplateByTemplateTypeAsync(Domain.Enums.EmailTemplateType.RecoverPassword, cancellationToken);

            if(template == null)
            {
                throw new ArgumentException($"Email Template {Domain.Enums.EmailTemplateType.RecoverPassword} does not exist");
            }

            var user = await _userRepository.GetByIdAsync(command.UserId, cancellationToken);

            if(user == null)
            {
                throw new ArgumentException($"User with email {user.Email} does not exist");
            }

            string content = ContentBuilder(command, user);

            var email = new EmailEntity
            {
                EmailId = Guid.NewGuid(),
                EmailAccountId = template.EmailAccountId,
                Content = content,
                Subject = template.Subject,
                Receiver = user.Email,
                EmailName = template.EmailName,
                Error = null,
                ProcessedDate = null,
                EmailAttacheds = template.EmailTemplateAttacheds.Select(c => new EmailAttachedEntity
                {
                    EmailAttachedId = c.EmailTemplateAttachedId,
                    FilePath = c.FilePath
                }).ToList()
            };
            email.AddDomainEvent(new SendRecoverPasswordDomainEvent(email.EmailId));

            await _emailRepository.AddAsync(email);

            return Unit.Value;
        }

        private string ContentBuilder(SendRecoverPasswordCommand command, UserEntity user)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/html/EmailRecoverPasswordPage.html");
            string body = System.IO.File.ReadAllText(path);

            StringBuilder content = new StringBuilder(body);
            content.Replace("[Link]", command.CallbackUrl);
            content.Replace("[FirstName]", user.FirstName);
            content.Replace("[LastName]", user.LastName);

            return content.ToString();
        }
    }
}
