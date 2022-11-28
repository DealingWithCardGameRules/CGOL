using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetAvailableActionsForCollectionHandler : IQueryHandler<GetAvailableActionsForCollection, Func<IAsyncEnumerable<IUserAction>>>
    {
        private readonly ICommandRepositoryQueries repository;
        private readonly IQueryDispatcher dispatcher;

        internal GetAvailableActionsForCollectionHandler(ICommandRepositoryQueries repository, IQueryDispatcher dispatcher)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task<Func<IAsyncEnumerable<IUserAction>>> Handle(GetAvailableActionsForCollection query)
        {
            async IAsyncEnumerable<IUserAction> Handle()
            {
                await foreach (var command in (await repository.GetCommands(query.PlayerIndex))())
                {
                    foreach (var col in command.Command.GetPlayFromMaybeQueries())
                    {
                        if ((await col.Value(dispatcher)).Equals(query.Collection, System.StringComparison.OrdinalIgnoreCase))
                        {
                            yield return command;
                        }
                    }
                }
            }
            return () => Handle();
        }
    }
}
