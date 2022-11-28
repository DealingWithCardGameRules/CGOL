using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState
{
    internal class PlayerSpecificCommandRepository : ICommandRepositoryQueries
    {
        private readonly IDispatcher dispatcher;
        private readonly ICommandRepositoryQueries repository;

        public PlayerSpecificCommandRepository(IDispatcher dispatcher, ICommandRepositoryQueries repository)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Func<IAsyncEnumerable<IUserAction>>> GetCommands(int? playerIndex = null)
        {
            async IAsyncEnumerable<IUserAction> Handler()
            {
                var player = await dispatcher.Dispatch(new CurrentPlayer());
                if (player == null)
                    await foreach (var command in (await repository.GetCommands())())
                        yield return command;

                if (playerIndex == player.Index)
                    await foreach (var command in (await repository.GetCommands(playerIndex))())
                        yield return command;
            }
            return () => Handler();
        }
    }
}
