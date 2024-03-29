﻿using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class SimplyAddCard : ICommandHandler<AddCard>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public SimplyAddCard(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(AddCard command, IEventDispatcher eventDispatcher)
        {
            var template = await dispatcher.Dispatch(new GetTemplate(command.Template));
            if (template == null)
                throw new ArgumentException($"The card template \"{command.Template}\" was not found. Remember to declare a card template before refering to it. Try {nameof(CreateCard)}");

            if (!await dispatcher.Dispatch(new HasCollection(command.Destination)))
                throw new ArgumentException($"The destination \"{command.Destination}\" was not found. Remember to declare a card collection before refering to it. Try {nameof(CreateDeck)}, {nameof(CreateHand)} or {nameof(CreateZone)}");

            var card = new SimpleLibraryCard(template);
            var @event = new CardAdded(timeProvider.Now, command.ProcessId, card, command.Destination);
            await eventDispatcher.Dispatch(@event);
        }
    }
}
