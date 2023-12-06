
namespace Jookli.Commander.Application.Contracts
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
