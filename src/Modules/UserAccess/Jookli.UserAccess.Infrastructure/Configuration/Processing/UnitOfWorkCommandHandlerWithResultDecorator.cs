using Jookli.BuildingBlocks.Infrastructure;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Application.Contracts;
using Jookli.UserAccess.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult> where T : ICommand<TResult>
    {
        private readonly ICommandHandler<T, TResult> _decorator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserAccessContext _userAccessContext;

        public UnitOfWorkCommandHandlerWithResultDecorator(ICommandHandler<T, TResult> decorator, IUnitOfWork unitOfWork, UserAccessContext userAccessContext)
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
                }

            }
            await this._unitOfWork.CommitAsync(cancellationToken);

            return result;
        }
    }
}
