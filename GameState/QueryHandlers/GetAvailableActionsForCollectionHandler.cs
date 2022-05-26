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

        internal GetAvailableActionsForCollectionHandler(ICommandRepositoryQueries repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public IEnumerable<IUserAction> Handle(GetAvailableActionsForCollection query)
        {
            foreach (var command in repository.GetCommands(query.PlayerIndex))
            {
                if (command.Command.GetPlayFroms().Contains(query.Collection))
                {
                    yield return command;
                }
            }
        }
    }
}
