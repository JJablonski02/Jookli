using Dapper;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.BuildingBlocks.Application.Events;
using Jookli.BuildingBlocks.Infrastructure.DomainEventsDispatching;
using MediatR;
using Newtonsoft.Json;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Infrastructure.Configuration.Processing.Outbox
{
    internal class ProcesOutboxCommandHandler
    {
        private readonly IMediator _mediator;

        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        private readonly IDomainNotificationsMapper _domainNotificationsMapper;

        public ProcesOutboxCommandHandler(IMediator mediator, ISqlConnectionFactory sqlConnectionFactory, IDomainNotificationsMapper domainNotificationsMapper)
        {
            _mediator = mediator;
            _sqlConnectionFactory = sqlConnectionFactory;
            _domainNotificationsMapper = domainNotificationsMapper;
        }

        public async Task<Unit> Handle(ProcessOutboxCommand command, CancellationToken cancellationToken)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();
            string sql = "SELECT " +
                         $"[OutboxMessage].[Id] AS [{nameof(OutboxMessageDto.Id)}], " +
                         $"[OutboxMessage].[Type] AS [{nameof(OutboxMessageDto.Type)}], " +
                         $"[OutboxMessage].[Data] AS [{nameof(OutboxMessageDto.Data)}] " +
                         "FROM [UserAccess_OutboxMessages] AS [OutboxMessage] " +
                         "WHERE [OutboxMessage].[ProcessedDate] IS NULL " +
                         "ORDER BY [OutboxMessage].[OccurredOn]";

            var messages = await connection.QueryAsync<OutboxMessageDto>(sql);
            var messagesList = messages.AsList();

            const string sqlUpdateProcessedDate = "UPDATE [UserAccess_OutboxMessages] " +
                                                  "SET [ProcessedDate] = @Date " +
                                                  "WHERE [Id] = @Id";
            if (messagesList.Count > 0)
            {
                foreach (var message in messagesList)
                {
                    var type = _domainNotificationsMapper.GetType(message.Type);
                    var @event = JsonConvert.DeserializeObject(message.Data, type) as IDomainEventNotification;

                    using (LogContext.Push(new OutboxMessageContextEnricher(@event)))
                    {
                        await this._mediator.Publish(@event, cancellationToken);

                        await connection.ExecuteAsync(sqlUpdateProcessedDate, new
                        {
                            Date = DateTime.UtcNow,
                            message.Id
                        });
                    }
                }
            }

            return Unit.Value;
        }

        private class OutboxMessageContextEnricher : ILogEventEnricher
        {
            private readonly IDomainEventNotification _notification;

            public OutboxMessageContextEnricher(IDomainEventNotification notification)
            {
                _notification = notification;
            }

            public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            {
                logEvent.AddOrUpdateProperty(new LogEventProperty("Context", new ScalarValue($"OutboxMessage:{_notification.Id.ToString()}")));
            }
        }
    }
}
