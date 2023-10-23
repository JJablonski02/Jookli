using MediatR;

namespace Jookli.BuildingBlocks.Infrastructure.DomainEventsDispatching
{
    public class UnitOfWorkCommandHandlerDecorator<T> : IRequestHandler<T, Unit> where T : IRequest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRequestHandler<T, Unit> _decorator;

        public UnitOfWorkCommandHandlerDecorator(IUnitOfWork unitOfWork, IRequestHandler<T, Unit> decorator)
        {
            _unitOfWork = unitOfWork;
            _decorator = decorator;
        }

        public async Task<Unit> Handle(T request, CancellationToken cancellationToken)
        {
            await this._decorator.Handle(request, cancellationToken);

            await this._unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
