using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetAvailableActionHandler : IQueryHandler<GetAvailableAction, ICommand?>
    {
        private readonly ICommandRepositoryQueries repository;

        internal GetAvailableActionHandler(ICommandRepositoryQueries repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public async Task<ICommand?> Handle(GetAvailableAction query)
        {
            var commands = (await repository.GetCommands(query.PlayerIndex))();
            return (await commands.FirstOrDefaultAsync(c => c.Command.Instance == query.Instance))?.Command;
        }
    }
}
