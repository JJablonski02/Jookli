using Dapper;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.Commander.Application.Configuration.Command;
using MediatR;
using Newtonsoft.Json;
using Polly;

namespace Jookli.Commander.Infrastructure.Configuration.Processing.InternalCommands
{
    internal class ProcessInternalCommandsCommandHandler : ICommandHandler<ProcessInternalCommandsCommand>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public ProcessInternalCommandsCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory= sqlConnectionFactory;
        }
        public async Task<Unit> Handle(ProcessInternalCommandsCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            string sql = "SELECT " +
                               $"Id AS '{nameof(InternalCommandDto.Id)}', " +
                               $"Type AS '{nameof(InternalCommandDto.Type)}', " +
                               $"Data AS '{nameof(InternalCommandDto.Data)}' " +
                               "FROM dbo.Commander_InternalCommands AS Command " +
                               "WHERE Command.ProcessedDate IS NULL " +
                               "ORDER BY Command.EnqueueDate";

            var commands = await connection.QueryAsync<InternalCommandDto>(sql);

            var internalCommandsList = commands.AsList();

            var policy = Policy.Handle<Exception>()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(3),
                });

            foreach(var internalCommand in internalCommandsList)
            {
                var result = await policy.ExecuteAndCaptureAsync(() => ProcessCommand(internalCommand));

                if(result.Outcome == OutcomeType.Failure)
                {
                    await connection.ExecuteScalarAsync(
                        "UPDATE dbo.Commander_InternalCommands " +
                        "SET ProcessedDate = @NowDate, " +
                        "Error = @Error " +
                        "WHERE Id = @Id",
                        new
                        {
                            NowDate = DateTime.UtcNow,
                            Error = result.FinalException.ToString(),
                            internalCommand.Id
                        });
                }
            }

            return Unit.Value;
        }

        private async Task ProcessCommand(InternalCommandDto internalCommand)
        {
            Type type = Assemblies.Application.GetType(internalCommand.Type);
            dynamic commandToProcess = JsonConvert.DeserializeObject(internalCommand.Data, type);

            await CommandsExecutor.Execute(commandToProcess);
        }

        private class InternalCommandDto
        {
            public Guid Id { get; set; }

            public string Type { get; set; }

            public string Data { get; set; }
        }
    }
}
