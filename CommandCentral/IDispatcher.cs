namespace dk.itu.game.msc.cgdl.Distribution
{
    public interface IDispatcher : IQueryDispatcher
    {
        void Dispatch(ICommand command);
    }
}
