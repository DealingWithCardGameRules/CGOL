using System.Threading.Tasks;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface IQueryDispatcher
    {
        T Dispatch<T>(IQuery<T> query);
        Task<T> DispatchAsync<T>(IQuery<T> query);
    }
}
