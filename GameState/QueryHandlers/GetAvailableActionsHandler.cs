using System.Collections.Generic;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetAvailableActionsHandler : IQueryHandler<GetAvailableActions, IEnumerable<IUserAction>>
    {
        private readonly ICommandRepositoryQueries repository;

        internal GetAvailableActionsHandler(ICommandRepositoryQueries repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public IEnumerable<IUserAction> Handle(GetAvailableActions query)
        {
            return repository.GetCommands(query.PlayerIndex);
        }
    }
}
