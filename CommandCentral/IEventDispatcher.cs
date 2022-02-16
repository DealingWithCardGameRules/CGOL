namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface IEventDispatcher
    {
        void Dispatch(IEvent @event);
    }
}
