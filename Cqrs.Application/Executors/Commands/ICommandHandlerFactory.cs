namespace Cqrs.Application.Executors.Commands
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand, TReturn> Create<TCommand, TReturn>();
        void Destroy<TCommand>(TCommand command);
    }
}
