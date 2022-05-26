using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.GameState
{
    internal class CommandComposite : ICommandRepositoryQueries
    {
        private readonly ICommandRepositoryQueries[] repositories;

        public IEnumerable<IUserAction> GetCommands(int? playerIndex = null)
        {
            foreach (var repository in repositories)
                foreach (var command in repository.GetCommands(playerIndex))
                    yield return command;
        }

        public CommandComposite(params ICommandRepositoryQueries[] repositories)
        {
            this.repositories = repositories ?? throw new System.ArgumentNullException(nameof(repositories));
        }
    }
}
