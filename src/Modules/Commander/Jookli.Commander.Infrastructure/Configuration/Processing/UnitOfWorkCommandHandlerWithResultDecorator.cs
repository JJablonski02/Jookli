using Jookli.BuildingBlocks.Infrastructure;
using Jookli.Commander.Application.Configuration.Command;
using Jookli.Commander.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Jookli.Commander.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult> where T : ICommand<TResult>
    {
        private readonly ICommandHandler<T, TResult> _decorator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly CommanderContext _gamesContext;

        public UnitOfWorkCommandHandlerWithResultDecorator(ICommandHandler<T, TResult> decorator, IUnitOfWork unitOfWork, CommanderContext userAccessContext)
        {
            _decorator = decorator;
            _unitOfWork = unitOfWork;
            _gamesContext = userAccessContext;
        }

        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var result = await this._decorator.Handle(command, cancellationToken);

            if (command is InternalCommandBase<TResult>)
            {
                var internalCommand = await _gamesContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (internalCommand is not null)
                {
                    internalCommand.ProcessedDate = DateTime.UtcNow;

                    _gamesContext.Update(internalCommand);
                }

            }
            await this._unitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}
