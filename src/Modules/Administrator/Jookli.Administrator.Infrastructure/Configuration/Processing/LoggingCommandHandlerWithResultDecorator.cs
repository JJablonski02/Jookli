using Jookli.BuildingBlocks.Application;
using Jookli.Administrator.Application.Configuration.Command;
using Jookli.Administrator.Application.Contracts;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Events;


namespace Jookli.Administrator.Infrastructure.Configuration.Processing
{
    internal class LoggingCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult> where T : ICommand<TResult>
    {
        private readonly ILogger _logger;
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly ICommandHandler<T, TResult> _decorator;

        public LoggingCommandHandlerWithResultDecorator(ILogger logger, IExecutionContextAccessor executionContextAccessor, ICommandHandler<T, TResult> decorator)
        {
            _logger = logger;
            _executionContextAccessor = executionContextAccessor;
            _decorator = decorator;
        }

        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
           using(
                LogContext.Push(
                    new RequestLogEnricher(_executionContextAccessor),
                    new CommandLogEnricher(command)))
            {
                try
                {
                    this._logger.Information(
                        "Executing command {@Command}",
                        command);

                    var result = await _decorator.Handle(command, cancellationToken);

                    this._logger.Information("Command processed successful, result {@Result}", result);
                    return result;

                }
                catch(Exception ex)
                {
                    this._logger.Error(ex, "Command processing failed");
                    throw;
                }
            }
        }

        private class CommandLogEnricher : ILogEventEnricher
        {
            private readonly ICommand<TResult> _command;

            public CommandLogEnricher(ICommand<TResult> command)
            {
                _command = command;
            }

            public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            {
                logEvent.AddOrUpdateProperty(new LogEventProperty("Context", new ScalarValue($"Command:{_command.Id.ToString()}")));
            } 
        }

        private class RequestLogEnricher : ILogEventEnricher
        {
            private readonly IExecutionContextAccessor _executionContextAccessor;
            public RequestLogEnricher(IExecutionContextAccessor executionContextAccessor)
            {
                _executionContextAccessor = executionContextAccessor;
            }

            public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            {
                if (_executionContextAccessor.IsAvailable)
                {
                    logEvent.AddOrUpdateProperty(new LogEventProperty("CorrelationId", new ScalarValue(_executionContextAccessor.CorrelationId)));
                }
            }
        }

    }
}
