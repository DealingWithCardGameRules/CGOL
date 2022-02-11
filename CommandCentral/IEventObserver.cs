namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface IEventObserver<TEvent> where TEvent : IEvent
    {
        void Invoke(TEvent @event);
    }
}
