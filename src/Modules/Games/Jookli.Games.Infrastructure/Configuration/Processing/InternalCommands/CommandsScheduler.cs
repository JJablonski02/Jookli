using Dapper;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.BuildingBlocks.Infrastructure.Serialization;
using Jookli.Games.Application.Configuration.Command;
using Jookli.Games.Application.Contracts;
using Newtonsoft.Json;

namespace Jookli.Games.Infrastructure.Configuration.Processing.InternalCommands
{
    public class CommandsScheduler : ICommandsScheduler
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public CommandsScheduler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task EnqueueAsync(ICommand command)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sqlInsert = "INSERT INTO dbo.Games_InternalCommands (Id, EnqueueDate, Type, Data) VALUES " +
                                     "(@Id, @EnqueueDate, @Type, @Data)";

            await connection.ExecuteAsync(sqlInsert, new
            {
                command.Id,
                EnqueueDate = DateTime.UtcNow,
                Type = command.GetType().FullName,
                Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
                {
                    ContractResolver = new AllPropertiesContractResolver()
                })
            }); 
        }

        public async Task EnqueueAsync<T>(ICommand<T> command)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sqlInsert = "INSERT INTO dbo.Games_InternalCommands (Id, EnqueueDate , Type, Data) VALUES " +
                                     "(@Id, @EnqueueDate, @Type, @Data)";

            await connection.ExecuteAsync(sqlInsert, new
            {
                command.Id,
                EnqueueDate = DateTime.UtcNow,
                Type = command.GetType().FullName,
                Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings 
                { 
                    ContractResolver = new AllPropertiesContractResolver()
                })
            });
        }
    }
}
