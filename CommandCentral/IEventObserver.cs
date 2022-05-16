namespace dk.itu.game.msc.cgdl.Distribution
{
    public interface IEventObserver<TEvent> where TEvent : IEvent
    {
        void Invoke(TEvent @event);
    }
}
