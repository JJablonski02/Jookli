using Jookli.Games.Application.Contracts;
using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Games.Application.Configuration.Command
{
    public abstract class InternalCommandBase : ICommand
    {
        public Guid Id { get; }

        protected InternalCommandBase(Guid id)
        {
            this.Id = id;
        }
    }

    public abstract class InternalCommandBase<TResult> : ICommand<TResult>
    {
        public Guid Id { get; }

        public InternalCommandBase()
        {
            this.Id = Guid.NewGuid();
        }

        public InternalCommandBase(Guid id)
        {
            this.Id = id;
        }
    }
}
