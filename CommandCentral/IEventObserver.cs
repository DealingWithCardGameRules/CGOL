namespace dk.itu.game.msc.cgol.Distribution
{
    public interface IEventObserver<TEvent> where TEvent : IEvent
    {
        void Invoke(TEvent @event);
    }
}
