using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Distribution
{
    public interface IEventDispatcher
    {
        Task Dispatch(IEvent @event);
    }
}
