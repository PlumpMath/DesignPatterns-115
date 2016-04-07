namespace Cqrs.Application.Executors.Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public CommandExecutor(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        public CommandResult<Void> Execute<TCommand>(TCommand command)
        {
            return Execute<TCommand, Void>(command);
        }

        public CommandResult<TReturn> Execute<TCommand, TReturn>(TCommand command)
        {
            ICommandHandler<TCommand, TReturn> handler = _commandHandlerFactory.Create<TCommand, TReturn>();
            try
            {
                var returnValue = handler.Handle(command);
                return CommandResult<TReturn>.Executed(returnValue);
            }           
            finally
            {
                _commandHandlerFactory.Destroy(handler);
            }
        }
    }
}
