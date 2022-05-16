namespace dk.itu.game.msc.cgdl.Distribution
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command, IEventDispatcher eventDispatcher);
    }
}
