using Jookli.BuildingBlocks.Infrastructure;
using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jookli.Commander.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> _decorator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CommanderContext _commanderContext;

        public UnitOfWorkCommandHandlerDecorator(ICommandHandler<T> decorator, IUnitOfWork unitOfWork, CommanderContext userAccessContext)
        {
            _decorator = decorator;
            _unitOfWork = unitOfWork;
            _commanderContext = userAccessContext;
        }

        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            await this._decorator.Handle(command, cancellationToken);

            if(command is InternalCommandBase)
            {
                var internalCommand = await _commanderContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if(internalCommand is not null)
                {
                    internalCommand.ProcessedDate = DateTime.UtcNow;
                }
            }

            await this._unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
