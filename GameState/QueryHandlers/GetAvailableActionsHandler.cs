using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetAvailableActionsHandler : IQueryHandler<GetAvailableActions, Func<IAsyncEnumerable<IUserAction>>>
    {
        private readonly ICommandRepositoryQueries repository;

        internal GetAvailableActionsHandler(ICommandRepositoryQueries repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public async Task<Func<IAsyncEnumerable<IUserAction>>> Handle(GetAvailableActions query)
        {
            async IAsyncEnumerable<IUserAction> Handle()
            {
                await foreach (var action in (await repository.GetCommands(query.PlayerIndex))())
                    yield return action;
            }
            return () => Handle();
        }
    }
}
