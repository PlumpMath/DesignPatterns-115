namespace Cqrs.Application.Executors.Commands
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand, Void>
    {
        public Void Handle(TCommand command)
        {
            DoHandle(command);
            return Void.Value;
        }

        protected abstract void DoHandle(TCommand command);
    }
}
