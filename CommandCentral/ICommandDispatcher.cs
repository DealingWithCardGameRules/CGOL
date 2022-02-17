namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface ICommandDispatcher
    {
        void Dispatch(ICommand command);
    }
}
