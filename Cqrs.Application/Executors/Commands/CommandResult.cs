namespace Cqrs.Application.Executors.Commands
{
    public class CommandResult<T>
    {
        public T ReturnValue { get; private set; }
        public CommandStatus Status { get; private set; }
        public string Message { get; private set; }

        public static CommandResult<T> Executed(T returnValue)
        {
            return new CommandResult<T>()
            {
                ReturnValue = returnValue,
                Status = CommandStatus.Executed
            };
        }

        public static CommandResult<T> Failed(string message)
        {
            return new CommandResult<T>()
            {
                Status = CommandStatus.Failed,
                Message = message
            };
        }
    }
}
