namespace dk.itu.game.msc.cgol.Distribution
{
    public interface IEventDispatcher
    {
        void Dispatch(IEvent @event);
    }
}
