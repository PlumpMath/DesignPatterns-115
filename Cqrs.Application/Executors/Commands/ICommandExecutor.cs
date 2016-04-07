namespace Cqrs.Application.Executors.Commands
{    
    public interface ICommandExecutor
    {
        CommandResult<Void> Execute<TCommand>(TCommand command);
        CommandResult<TReturnValue> Execute<TCommand, TReturnValue>(TCommand command);
    }
}
