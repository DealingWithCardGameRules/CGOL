namespace dk.itu.game.msc.cgol.Distribution
{
    public interface IUserAction
    {
        ICommand Command { get; }
        string Label { get; }
    }
}
