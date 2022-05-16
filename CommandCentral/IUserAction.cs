namespace dk.itu.game.msc.cgdl.Distribution
{
    public interface IUserAction
    {
        ICommand Command { get; }
        string Label { get; }
    }
}
