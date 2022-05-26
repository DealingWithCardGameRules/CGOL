using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class CollectionOwnerHandler : ICommandHandler<CollectionOwner>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public CollectionOwnerHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(CollectionOwner command, IEventDispatcher eventDispatcher)
        {
            var player = command.PlayerIndex ?? CurrentPlayer();
            var players = dispatcher.Dispatch(new GetNumberOfPlayers());
            if (players < player)
                throw new ArgumentException("Owners player index is larger than the maximum number of players.", nameof(command.PlayerIndex));

            eventDispatcher.Dispatch(new CollectionOwnerSet(timeProvider.Now, command.Instance, command.Collection, player));
        }

        private int CurrentPlayer()
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new ArgumentException($"No player index set and no current player. Remember to setup players using {nameof(SetPlayers)}");
            return player.Index;
        }
    }
}
