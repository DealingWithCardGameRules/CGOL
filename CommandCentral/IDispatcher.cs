namespace dk.itu.game.msc.cgol.Distribution
{
    public interface IDispatcher : IQueryDispatcher
    {
        void Dispatch(ICommand command);
    }
}
