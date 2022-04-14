using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetAvailableActionHandler : IQueryHandler<GetAvailableAction, ICommand?>
    {
        private readonly ICommandRepositoryQueries repository;

        public GetAvailableActionHandler(ICommandRepositoryQueries repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public ICommand? Handle(GetAvailableAction query)
        {
            return repository.Commands.FirstOrDefault(c => c.Command.Instance == query.Instance)?.Command;
        }
    }
}
