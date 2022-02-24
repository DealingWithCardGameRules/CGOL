using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyAddCard : ICommandHandler<AddCard>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyAddCard(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
        }

        public void Handle(AddCard command, IEventDispatcher eventDispatcher)
        {
            var @event = new CardAdded(timeProvider.Now, command.ProcessId, command.Card, command.DestinationId);
            eventDispatcher.Dispatch(@event);
        }
    }
}
