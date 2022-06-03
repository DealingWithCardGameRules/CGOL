using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameEvents
{
    public interface IEventSerializer
    {
        string Serialize(IEvent @event);
    }
}
