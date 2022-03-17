using System.Collections.Generic;
using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetAvailableActionsHandler : IQueryHandler<GetAvailableActions, IEnumerable<ICommand>>
    {
        private readonly CommandRepository repository;

        public GetAvailableActionsHandler(CommandRepository repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public IEnumerable<ICommand> Handle(GetAvailableActions _)
        {
            return repository.Commands;
        }
    }
}
