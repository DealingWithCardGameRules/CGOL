using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState
{
    internal class CommandComposite : ICommandRepositoryQueries
    {
        private readonly ICommandRepositoryQueries[] repositories;

        public async Task<Func<IAsyncEnumerable<IUserAction>>> GetCommands(int? playerIndex = null)
        {
            async IAsyncEnumerable<IUserAction> Handler() 
            {
                foreach (var repository in repositories)
                    await foreach (var command in (await repository.GetCommands(playerIndex))())
                        yield return command;
            }
            return () => Handler();
        }

        public CommandComposite(params ICommandRepositoryQueries[] repositories)
        {
            this.repositories = repositories ?? throw new System.ArgumentNullException(nameof(repositories));
        }
    }
}
