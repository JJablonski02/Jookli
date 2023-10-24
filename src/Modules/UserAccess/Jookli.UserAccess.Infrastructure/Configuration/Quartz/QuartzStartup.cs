﻿using Jookli.UserAccess.Infrastructure.Configuration.Processing.Inbox;
using Jookli.UserAccess.Infrastructure.Configuration.Processing.Outbox;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using System.Collections.Specialized;


namespace Jookli.UserAccess.Infrastructure.Configuration.Quartz
{
    internal static class QuartzStartup
    {
        internal static void Initialize(ILogger logger, long? internalProcessingPoolingInterval = null)
        {
            logger.Information("Quartz starting...");

            var schedulerConfiguration = new NameValueCollection();

            schedulerConfiguration.Add("quartz.scheduler.instanceName", "Jookli");

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(schedulerConfiguration);
            IScheduler scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

            LogProvider.SetCurrentLogProvider(new SerilogLogProvider(logger));

            scheduler.Start().GetAwaiter().GetResult();

            var processOutboxJob = JobBuilder.Create<ProcessOutboxJob>().Build();

            ITrigger trigger;

            if (internalProcessingPoolingInterval.HasValue)
            {
                trigger = TriggerBuilder.Create().StartNow().WithSimpleSchedule(x =>
                {
                    x.WithInterval(TimeSpan.FromMilliseconds(internalProcessingPoolingInterval.Value)).RepeatForever();
                }).Build();
            }
            else
            {
                trigger = TriggerBuilder.Create().StartNow().WithCronSchedule("0/2 * * ? * *").Build();
            }

            scheduler.ScheduleJob(processOutboxJob, trigger).GetAwaiter().GetResult();

            var processInboxJob = JobBuilder.Create<ProcessInboxJob>().Build();

        }
    }
}