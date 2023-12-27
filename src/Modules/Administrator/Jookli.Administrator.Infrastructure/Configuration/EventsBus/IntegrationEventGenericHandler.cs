using Autofac;
using Dapper;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.BuildingBlocks.Infrastructure.Serialization;
using Newtonsoft.Json;

namespace Jookli.Administrator.Infrastructure.Configuration.EventsBus
{
    internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T> where T : IntegrationEvent
    {
        public async Task Handle(T @event)
        {
            using(var scope = AdministratorCompositionRoot.BeginLifetimeScope())
            {
                using (var connection = scope.Resolve<ISqlConnectionFactory>().GetOpenConnection())
                {
                    string type = @event.GetType().FullName;
                    var data = JsonConvert.SerializeObject(@event, new JsonSerializerSettings
                    {
                        ContractResolver = new AllPropertiesContractResolver()
                    });

                    var sql = "INSERT INTO dbo.Administrator_InboxMessage (Id, OccuredOn, Type, Data) " +
                        "VALUES (@Id, @OccuredOn, @Type, @Data)";

                    await connection.ExecuteScalarAsync(sql, new
                    {
                        @event.Id,
                        @event.OccuredOn,
                        type,
                        data
                    });
                }
            }
        }
    }
}
