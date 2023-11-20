using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Application.Contracts
{
    public abstract class CommandBase : ICommand
    {
        public Guid Id { get; }
        protected CommandBase()
        {
            this.Id = Guid.NewGuid();
        }

        protected CommandBase(Guid id)
        {
            this.Id = id;
        }
    }

    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        public Guid Id { get; }
        public CommandBase()
        {
            this.Id = Guid.NewGuid();
        }

        public CommandBase(Guid id)
        {
            Id = id;
        }
    }
}
