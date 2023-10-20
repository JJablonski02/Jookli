using Jookli.BuildingBlocks.Infrastructure;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Application.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Configuration.Processing
{
    internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> _decorator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserAccessContext _userAccessContext;

        public UnitOfWorkCommandHandlerDecorator(ICommandHandler<T> decorator, IUnitOfWork unitOfWork, UserAccessContext userAccessContext)
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
