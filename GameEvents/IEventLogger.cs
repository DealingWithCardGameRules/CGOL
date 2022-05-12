using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameEvents
{
    public interface IEventLogger
    {
        void AppendLog(IEvent @event);
    }
}
