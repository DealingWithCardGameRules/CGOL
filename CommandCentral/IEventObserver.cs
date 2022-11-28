using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Distribution
{
    public interface IEventObserver<TEvent> where TEvent : IEvent
    {
        Task Invoke(TEvent @event);
    }
}
