using Jookli.Commander.Application.Contracts;

namespace Jookli.Commander.Application.Configuration.Command
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
