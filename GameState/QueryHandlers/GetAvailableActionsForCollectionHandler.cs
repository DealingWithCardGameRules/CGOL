using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetAvailableActionsForCollectionHandler : IQueryHandler<GetAvailableActionsForCollection, IEnumerable<IUserAction>>
    {
        private readonly ICommandRepositoryQueries repository;
        private readonly IQueryDispatcher dispatcher;

        internal GetAvailableActionsForCollectionHandler(ICommandRepositoryQueries repository, IQueryDispatcher dispatcher)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public IEnumerable<IUserAction> Handle(GetAvailableActionsForCollection query)
        {
            foreach (var command in repository.GetCommands(query.PlayerIndex))
            {
                foreach (var col in command.Command.GetPlayFromMaybeQueries())
                {
                    if (col.Value(dispatcher).Equals(query.Collection, System.StringComparison.OrdinalIgnoreCase))
                    {
                        yield return command;
                        continue;
                    }
                }
            }
        }
    }
}
