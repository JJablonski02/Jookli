using Jookli.BuildingBlocks.Infrastructure;
using Jookli.Payments.Application.Configuration.Command;
using Jookli.Payments.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult> where T : ICommand<TResult>
    {
        private readonly ICommandHandler<T, TResult> _decorator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaymentsContext _userAccessContext;

        public UnitOfWorkCommandHandlerWithResultDecorator(ICommandHandler<T, TResult> decorator, IUnitOfWork unitOfWork, PaymentsContext userAccessContext)
        {
            _decorator = decorator;
            _unitOfWork = unitOfWork;
            _userAccessContext = userAccessContext;
        }

        public async Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var result = await this._decorator.Handle(command, cancellationToken);

            if (command is InternalCommandBase<TResult>)
            {
                var internalCommand = await _userAccessContext.InternalCommands.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                if (internalCommand is not null)
                {
                    internalCommand.ProcessedDate = DateTime.UtcNow;

                    _userAccessContext.Update(internalCommand);
                }

            }
            await this._unitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}
