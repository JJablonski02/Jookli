using Jookli.BuildingBlocks.Infrastructure;
using Jookli.Payments.Application.Configuration.Command;
using Jookli.Payments.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jookli.Payments.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> _decorator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaymentsContext _userAccessContext;

        public UnitOfWorkCommandHandlerDecorator(ICommandHandler<T> decorator, IUnitOfWork unitOfWork, PaymentsContext userAccessContext)
        {
            _decorator = decorator;
            _unitOfWork = unitOfWork;
            _userAccessContext = userAccessContext;
        }

        public async Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            await this._decorator.Handle(command, cancellationToken);

            if(command is InternalCommandBase)
            {
                var internalCommand = await _userAccessContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

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
