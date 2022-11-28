using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Distribution
{
    public interface IDispatcher : IQueryDispatcher
    {
        Task Dispatch(ICommand command);
    }
}
