using FluentValidation;
using Jookli.BuildingBlocks.Application.Exceptions;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Application.Contracts;

namespace Jookli.UserAccess.Infrastructure.Configuration.Processing
{
    internal class ValidationCommandHandlerWithResultDecorator<T, TResult> : ICommandHandler<T, TResult> where T : ICommand<TResult>
    {
        private readonly IList<IValidator<T>> _validators;

        private readonly ICommandHandler<T, TResult> _decorator;

        public ValidationCommandHandlerWithResultDecorator(IList<IValidator<T>> validators, ICommandHandler<T, TResult> decorator)
        {
            _validators = validators;
            _decorator = decorator;
        }

        public Task<TResult> Handle(T command, CancellationToken cancellationToken)
        {
            var errors = _validators.Select(v => v.Validate(command))
                .SelectMany(er => er.Errors)
                .Where(error => error != null).ToList();

            if(errors.Any())
            {
                throw new InvalidCommandException(errors.Select(er => er.ErrorMessage).ToList());
            }

            return _decorator.Handle(command, cancellationToken);
        }
    }
}
