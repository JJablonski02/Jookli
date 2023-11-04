using Autofac;
using Dapper;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.BuildingBlocks.Infrastructure.EventsBus;
using Jookli.BuildingBlocks.Infrastructure.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Infrastructure.Configuration.EventsBus
{
    internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T> where T : IntegrationEvent
    {
        public async Task Handle(T @event)
        {
            using(var scope = PaymentsCompositionRoot.BeginLifetimeScope())
            {
                using (var connection = scope.Resolve<ISqlConnectionFactory>().GetOpenConnection())
                {

                    string type = @event.GetType().FullName;
                    var data = JsonConvert.SerializeObject(@event, new JsonSerializerSettings
                    {
                        ContractResolver = new AllPropertiesContractResolver()
                    });

                    var sql = "INSERT INTO [UserAccess_InboxMessage] (Id, OccuredOn, Type, Data) " +
                        "VALUES (@Id, @OccuredOn, @Type, @Data";

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
