using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal class PlayerSpecificCommandRepository : ICommandRepositoryQueries
    {
        private readonly IDispatcher dispatcher;
        private readonly ICommandRepositoryQueries repository;

        public PlayerSpecificCommandRepository(IDispatcher dispatcher, ICommandRepositoryQueries repository)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public IEnumerable<IUserAction> GetCommands(int? playerIndex = null)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                return repository.GetCommands();

            if (playerIndex == player.Index)
                return repository.GetCommands(playerIndex);
            return new List<IUserAction>();
        }
    }
}
