namespace dk.itu.game.msc.cgdl.Distribution
{
    public interface IEventDispatcher
    {
        void Dispatch(IEvent @event);
    }
}
