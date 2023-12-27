using Jookli.BuildingBlocks.Infrastructure;
using Jookli.Administrator.Application.Configuration.Command;
using Jookli.Administrator.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jookli.Administrator.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> _decorator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AdministratorContext _gamesContext;

        public UnitOfWorkCommandHandlerDecorator(ICommandHandler<T> decorator, IUnitOfWork unitOfWork, AdministratorContext userAccessContext)
        {
            _decorator = decorator;
            _unitOfWork = unitOfWork;
            _gamesContext = userAccessContext;
        }

        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            await this._decorator.Handle(command, cancellationToken);

            if(command is InternalCommandBase)
            {
                var internalCommand = await _gamesContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

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
