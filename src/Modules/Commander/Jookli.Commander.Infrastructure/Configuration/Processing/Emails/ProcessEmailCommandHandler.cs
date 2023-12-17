using AutoMapper;
using AutoMapper.Internal;
using Dapper;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.BuildingBlocks.Infrastructure.InternalCommands;
using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Config;
using Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Dto;
using Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Sender;
using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Commander.Infrastructure.Configuration.Processing.Emails
{
    internal class ProcessEmailCommandHandler : ICommandHandler<ProcessEmailCommand>
    {
        private readonly IMediator _medatior;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ProcessEmailCommandHandler(IMediator mediator, ISqlConnectionFactory sqlConnectionFactory)
        {
            _medatior = mediator;
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<Unit> Handle(ProcessEmailCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            var sqlQuery = "SELECT " +
                        $"Email.EmailId AS {nameof(EmailDto.EmailId)}, " +
                        $"Email.EmailAccountId AS {nameof(EmailDto.EmailAccountId)}, " +
                        $"Email.EmailName AS {nameof(EmailDto.EmailName)}, " +
                        $"Email.Subject AS {nameof(EmailDto.Subject)}, " +
                        $"Email.Content AS {nameof(EmailDto.Content)}, " +
                        $"Email.Receiver AS {nameof(EmailDto.Receiver)}, " +
                        $"EmailAttached.EmailAttachedId AS EmailAttached_{nameof(EmailAttachedDto.EmailAttachedId)}, " +
                        $"EmailAttached.EmailId AS EmailAttached_{nameof(EmailAttachedDto.EmailId)}, " +
                        $"EmailAttached.FilePath AS EmailAttached_{nameof(EmailAttachedDto.FilePath)}, " +
                        $"EmailAttached.Name AS EmailAttached_{nameof(EmailAttachedDto.Name)}, " +
                        $"EmailAccount.EmailAccountId AS EmailAccount_{nameof(EmailAccountDto.EmailAccountId)}, " +
                        $"EmailAccount.Name AS EmailAccount_{nameof(EmailAccountDto.Name)}, " +
                        $"EmailAccount.EmailAddress AS EmailAccount_{nameof(EmailAccountDto.EmailAddress)}, " +
                        $"EmailAccount.SmtpServer AS EmailAccount_{nameof(EmailAccountDto.SmtpServer)}, " +
                        $"EmailAccount.SmtpPort AS EmailAccount_{nameof(EmailAccountDto.SmtpPort)}, " +
                        $"EmailAccount.SmtpLogin AS EmailAccount_{nameof(EmailAccountDto.SmtpLogin)}, " +
                        $"EmailAccount.SmtpPassword AS EmailAccount_{nameof(EmailAccountDto.SmtpPassword)} " +
                        $"FROM Commander_Email AS Email " +
                        $"LEFT JOIN Commander_EmailAccount AS EmailAccount ON Email.EmailAccountId = EmailAccount.EmailAccountId " +
                        $"LEFT JOIN Commander_EmailAttached AS EmailAttached ON Email.EmailId = EmailAttached.EmailId " +
                        "WHERE Email.ProcessedDate IS NULL";

            dynamic emailJobs = await connection.QueryAsync(sqlQuery);

            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(EmailDto), new[] { "EmailId" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(EmailAttachedDto), new[] { "EmailAttachedId" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(EmailAccountDto), new[] { "EmailAccountId" });

            var emailJobsList = (Slapper.AutoMapper.MapDynamic<EmailDto>(emailJobs) as IEnumerable<EmailDto>).ToList();

            var policy = Policy
               .Handle<Exception>()
               .WaitAndRetryAsync(new[]
               {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3)
               });

            foreach (var emailJob in emailJobsList)
            {
                var result = await policy.ExecuteAndCaptureAsync(() => ProcessSendEmailCommand(emailJob));

                if (result.Outcome == OutcomeType.Failure)
                {
                    await connection.ExecuteScalarAsync(
                        "UPDATE dbo.Commander_Email " +
                        "SET ProcessedDate = @NowDate, " +
                        "Error = @Error " +
                        "WHERE EmailId = @EmailId",
                        new
                        {
                            NowDate = DateTime.UtcNow,
                            Error = result.FinalException.ToString(),
                            EmailId = emailJob.EmailId
                        });
                }
                else
                {
                    await connection.ExecuteScalarAsync(
                                            "UPDATE dbo.Commander_Email " +
                                            "SET ProcessedDate = @NowDate, " +
                                            "Error = NULL " +
                                            "WHERE EmailId = @EmailId",
                                            new
                                            {
                                                NowDate = DateTime.UtcNow,
                                                EmailId = emailJob.EmailId
                                            });
                }
            }

            return Unit.Value;
        }

        private async Task ProcessSendEmailCommand(EmailDto email)
        {
            var options = SenderConfiguration(email.EmailAccount.SmtpServer,
                email.EmailAccount.SmtpPort,
                email.EmailAccount.SmtpLogin,
                email.EmailAccount.SmtpPassword,
                email.EmailAccount.EmailAddress,
                email.EmailName,
                true
                );

            IEmailSender jookliEmailSender = new EmailSender(options);

            await jookliEmailSender.SendAsync(async mailMessageBuild =>
            {
                var emailBuilder = mailMessageBuild.From(jookliEmailSender.DefaultSenderAddress, jookliEmailSender.DefaultSenderName)
                .To(email.Receiver)
                .WithBody(email.Content)
                .IsBodyHtml(true)
                .WithSubject(email.Subject);

                if (email.EmailAttached != null && email.EmailAttached.Count > 0)
                {

                }
            });
        }

        private IOptions<EmailSenderConfiguration> SenderConfiguration(string host, int? port, string login, string password, string defaultEmail, string defaultName, bool ssl)
        {
            EmailSenderConfiguration emailSenderConfiguration = EmailSenderConfiguration.New
                .OnHost(host)
                .OnPort(port.GetValueOrDefault())
                .OnCredentials(login, password)
                .WithDefaultSenderAddress(login)
                .WithDefaultSenderDisplayName(defaultName)
                .EnableSSL(ssl);

            IOptions<EmailSenderConfiguration> options = Options.Create(emailSenderConfiguration);

            return options;
        }
    }
}
