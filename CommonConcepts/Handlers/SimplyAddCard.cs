﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
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

        public void Handle(AddCard command, IEventDispatcher eventDispatcher)
        {
            var template = dispatcher.Dispatch(new GetTemplate(command.Template));
            var card = new SimpleLabraryCard(template);
            var @event = new CardAdded(timeProvider.Now, command.ProcessId, card, command.Destination);
            eventDispatcher.Dispatch(@event);
        }
    }
}
