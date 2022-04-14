using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetAvailableActionsForCollectionHandler : IQueryHandler<GetAvailableActionsForCollection, IEnumerable<IUserAction>>
    {
        private readonly ICommandRepositoryQueries repository;

        public GetAvailableActionsForCollectionHandler(ICommandRepositoryQueries repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public IEnumerable<IUserAction> Handle(GetAvailableActionsForCollection query)
        {
            foreach (var command in repository.Commands)
            {
                if (command.Command.GetPlayFroms().Contains(query.Collection))
                {
                    yield return command;
                }
            }
        }
    }
}
