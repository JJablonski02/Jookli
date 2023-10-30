

using Jookli.BuildingBlocks.Application.Data;
using Jookli.UserAccess.Application.Configuration.Command;
using MediatR;

namespace Jookli.UserAccess.Infrastructure.Configuration.Processing.InternalCommands
{
    internal class ProcessInternalCommandsCommandHandler : ICommandHandler<ProcessInternalCommandsCommand>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public Task<Unit> Handle(ProcessInternalCommandsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
