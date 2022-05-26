using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameEvents
{
    public interface IEventLogger
    {
        void AppendLog(IEvent @event);
    }
}
