namespace Cqrs.Application.Executors.Commands
{
    public interface ICommandHandler
    {

    }

    public interface ICommandHandler<in TCommand, out TReturn> : ICommandHandler
    {
        TReturn Handle(TCommand command);
    }
}
