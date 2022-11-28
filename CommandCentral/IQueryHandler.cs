using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Distribution
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
