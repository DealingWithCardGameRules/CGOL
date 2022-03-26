namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface IUserCommand
    {
        ICommand Command { get; }
        string Label { get; }
    }
}
