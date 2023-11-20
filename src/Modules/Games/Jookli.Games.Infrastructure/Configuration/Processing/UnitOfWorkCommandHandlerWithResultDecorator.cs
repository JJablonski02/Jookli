using Jookli.BuildingBlocks.Infrastructure;
using Jookli.Games.Application.Configuration.Command;
using Jookli.Games.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult> where T : ICommand<TResult>
    {
        private readonly ICommandHandler<T, TResult> _decorator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly GamesContext _gamesContext;

        public UnitOfWorkCommandHandlerWithResultDecorator(ICommandHandler<T, TResult> decorator, IUnitOfWork unitOfWork, GamesContext userAccessContext)
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
