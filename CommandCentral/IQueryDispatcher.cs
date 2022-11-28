using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Distribution
{
    public interface IQueryDispatcher
    {
        Task<T> Dispatch<T>(IQuery<T> query);
    }
}
