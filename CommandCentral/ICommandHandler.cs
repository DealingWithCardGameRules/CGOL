namespace dk.itu.game.msc.cgol.Distribution
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command, IEventDispatcher eventDispatcher);
    }
}
