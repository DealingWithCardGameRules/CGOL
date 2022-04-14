using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal class CommandComposite : ICommandRepositoryQueries
    {
        private readonly ICommandRepositoryQueries[] repositories;
        public IEnumerable<IUserAction> Commands => GetCommands();

        private IEnumerable<IUserAction> GetCommands()
        {
            foreach (var repository in repositories)
                foreach (var command in repository.Commands)
                    yield return command;
        }

        public CommandComposite(params ICommandRepositoryQueries[] repositories)
        {
            this.repositories = repositories ?? throw new System.ArgumentNullException(nameof(repositories));
        }
    }
}
