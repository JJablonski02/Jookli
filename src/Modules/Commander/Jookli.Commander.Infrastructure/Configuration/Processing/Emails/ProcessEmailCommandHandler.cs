using Dapper;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Infrastructure.Configuration.Processing.Emails.Dto;
using MediatR;
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
                        $"Email.Id AS {nameof(EmailDto.EmailJobQueueId)}, " +
                        $"Email.EmailAccountId AS {nameof(EmailDto.EmailAccountId)}, " +
                        $"Email.EmailName AS {nameof(EmailDto.EmailName)}, " +
                        $"Email.Subject AS {nameof(EmailDto.Subject)}, " +
                        $"Email.Content AS {nameof(EmailDto.Content)}, " +
                        $"Email.Recipient AS {nameof(EmailDto.Recipient)}, " +
                        $"EmailAttached.Id AS {nameof(EmailAttachedDto.EmailAttachedId)}, " +
                        $"EmailAttached.EmailId AS {nameof(EmailAttachedDto.EmailId)}, " +
                        $"EmailAttached.FilePath AS {nameof(EmailAttachedDto.FilePath)}, " +
                        $"EmailAttached.Name AS {nameof(EmailAttachedDto.Name)}, " +
                        $"EmailAccount.Id AS {nameof(EmailAccountDto.EmailAccountId)}, " +
                        $"EmailAccount.Name AS {nameof(EmailAccountDto.Name)}, " +
                        $"EmailAccount.EmailAddress AS {nameof(EmailAccountDto.EmailAddress)}, " +
                        $"EmailAccount.SmtpServer AS {nameof(EmailAccountDto.SmtpServer)}, " +
                        $"EmailAccount.SmtpPort AS {nameof(EmailAccountDto.SmtpPort)}, " +
                        $"EmailAccount.SmtpLogin AS {nameof(EmailAccountDto.SmtpLogin)}, " +
                        $"EmailAccount.SmtpPassword AS {nameof(EmailAccountDto.SmtpPassword)} " +
                        $"FROM Commander_Email AS Email " +
                        $"LEFT JOIN Commander_EmailAccount AS EmailAccount ON Email.EmailAccountId = EmailAccount.EmailAccountId " +
                        $"LEFT JOIN Commander_EmailAttached AS EmailAttached ON Email.Id = EmailAttached.EmailAttachedId " +
                        "WHERE Email.ProcessedDate IS NULL";

            dynamic emailJobs = await connection.QueryAsync<dynamic>(sqlQuery);

            return Unit.Value;
        }
    }
}
