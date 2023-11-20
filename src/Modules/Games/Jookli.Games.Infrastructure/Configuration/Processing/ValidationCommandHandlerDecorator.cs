using FluentValidation;
using Jookli.BuildingBlocks.Application.Exceptions;
using Jookli.Games.Application.Configuration.Command;
using Jookli.Games.Application.Contracts;
using MediatR;

namespace Jookli.Games.Infrastructure.Configuration.Processing
{
    public class ValidationCommandHandlerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly IList<IValidator<T>> _validators;
        private readonly ICommandHandler<T> _decorator;

        public ValidationCommandHandlerDecorator(IList<IValidator<T>> validators, ICommandHandler<T> decorator)
        {
            _validators = validators;
            _decorator = decorator;
        }

        public Task<Unit> Handle(T command, CancellationToken cancellationToken)
        {
            var errors = _validators.Select(v => v.Validate(command))
                .SelectMany(result => result.Errors).Where(er => er != null)
                .ToList();

            if (errors.Any())
            {
                throw new InvalidCommandException(errors.Select(er => er.ErrorMessage).ToList());
            }

            return _decorator.Handle(command, cancellationToken);
        }
    }
}
