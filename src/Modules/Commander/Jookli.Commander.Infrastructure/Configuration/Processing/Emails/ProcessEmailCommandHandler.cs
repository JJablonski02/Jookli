using AutoMapper;
using AutoMapper.Internal;
using Dapper;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Dto;
using MediatR;
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


            return Unit.Value;
        }
    }
}
