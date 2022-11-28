using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class CardOwnerHandler : ICommandHandler<CardOwner>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public CardOwnerHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(CardOwner command, IEventDispatcher eventDispatcher)
        {
            if (command.CardId == null)
                throw new ArgumentNullException("No card instance id set, make sure the card is attached as a card effect.");

            var players = await dispatcher.Dispatch(new GetNumberOfPlayers());
            if (players < command.PlayerIndex)
                throw new ArgumentException("Owners player index is larger than the maximum number of players.", nameof(command.PlayerIndex));

            await eventDispatcher.Dispatch(new CardOwnerSet(timeProvider.Now, command.ProcessId, command.CardId.Value, command.PlayerIndex));
        }
    }
}
