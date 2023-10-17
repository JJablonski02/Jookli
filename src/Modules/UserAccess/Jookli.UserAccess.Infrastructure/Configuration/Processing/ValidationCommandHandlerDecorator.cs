using FluentValidation;
using Jookli.BuildingBlocks.Application;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Infrastructure.Configuration.Processing
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
                .SelectMany(result => result.Errors).Where(er => er is not null)
                .ToList();

            if (errors.Any())
            {
                throw new InvalidCommandException(errors.Select(er => er.ErrorMessage).ToList());
            }

            return _decorator.Handle(command, cancellationToken);
        }
    }
}
