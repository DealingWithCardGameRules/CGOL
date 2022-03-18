using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetAvailableActionsForCollectionHandler : IQueryHandler<GetAvailableActionsForCollection, IEnumerable<ICommand>>
    {
        private readonly CommandRepository repository;

        public GetAvailableActionsForCollectionHandler(CommandRepository repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public IEnumerable<ICommand> Handle(GetAvailableActionsForCollection query)
        {
            foreach (var command in repository.Commands)
            {
                if (command.GetPlayFroms().Contains(query.Collection))
                {
                    yield return command;
                }
            }
        }
    }
}
