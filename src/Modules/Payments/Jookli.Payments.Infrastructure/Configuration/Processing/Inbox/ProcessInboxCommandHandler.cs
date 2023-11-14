using Dapper;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.Payments.Application.Configuration.Command;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Infrastructure.Configuration.Processing.Inbox
{
    internal class ProcessInboxCommandHandler : ICommandHandler<ProcessInboxCommand>
    {
        private readonly IMediator _mediator;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ProcessInboxCommandHandler(IMediator mediator, ISqlConnectionFactory sqlConnectionFactory)
        {
            _mediator= mediator;
            _sqlConnectionFactory= sqlConnectionFactory;
        }
       
        public async Task<Unit> Handle(ProcessInboxCommand command, CancellationToken cancellationToken)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();
            string sql = "SELECT " +
                         $"Id AS '{nameof(InboxMessageDto.Id)}', " +
                         $"Type AS '{nameof(InboxMessageDto.Type)}', " +
                         $"Data AS '{nameof(InboxMessageDto.Data)}' " +
                         "FROM dbo.Payments_InboxMessage AS InboxMessage " +
                         "WHERE InboxMessage.ProcessedDate IS NULL " +
                         "ORDER BY InboxMessage.OccurredOn";

            var messages = await connection.QueryAsync<InboxMessageDto>(sql);

            const string sqlUpdateProcessedDate = "UPDATE dbo.Payments_InboxMessages " +
                                                  "SET ProcessedDate = @Date " +
                                                  "WHERE Id = @Id";

            foreach (var message in messages)
            {
                var messageAssembly = AppDomain.CurrentDomain.GetAssemblies()
                    .SingleOrDefault(assembly => message.Type.Contains(assembly.GetName().Name));

                Type type = messageAssembly.GetType(message.Type);
                var request = JsonConvert.DeserializeObject(message.Data, type);

                try
                {
                    await _mediator.Publish((INotification)request, cancellationToken);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                await connection.ExecuteAsync(sqlUpdateProcessedDate, new
                {
                    Date = DateTime.UtcNow,
                    message.Id
                });
            }

            return Unit.Value;
        }
    }
}
