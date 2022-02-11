namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
