using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetAvailableActionHandler : IQueryHandler<GetAvailableAction, ICommand?>
    {
        private readonly CommandRepository repository;

        public GetAvailableActionHandler(CommandRepository repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public ICommand? Handle(GetAvailableAction query)
        {
            return repository.Commands.FirstOrDefault(c => c.Instance == query.Instance);
        }
    }
}
