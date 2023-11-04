using Jookli.Payments.Infrastructure.Configuration.Processing;
using Jookli.Payments.Infrastructure.Configuration.Processing.Inbox;
using Quartz;


namespace Jookli.UserAccess.Infrastructure.Configuration.Processing.Inbox
{
    [DisallowConcurrentExecution]
    public class ProcessInboxJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            await CommandsExecutor.Execute(new ProcessInboxCommand());
        }
    }
}
