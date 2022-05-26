using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Linq;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetAvailableActionHandler : IQueryHandler<GetAvailableAction, ICommand?>
    {
        private readonly ICommandRepositoryQueries repository;

        internal GetAvailableActionHandler(ICommandRepositoryQueries repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public ICommand? Handle(GetAvailableAction query)
        {
            var commands = repository.GetCommands(query.PlayerIndex);
            return commands.FirstOrDefault(c => c.Command.Instance == query.Instance)?.Command;
        }
    }
}
