using System.Collections.Generic;
using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetAvailableActionsHandler : IQueryHandler<GetAvailableActions, IEnumerable<IUserAction>>
    {
        private readonly ICommandRepositoryQueries repository;

        public GetAvailableActionsHandler(ICommandRepositoryQueries repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public IEnumerable<IUserAction> Handle(GetAvailableActions _)
        {
            return repository.Commands;
        }
    }
}
