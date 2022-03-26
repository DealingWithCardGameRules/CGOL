﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyRevealAndMove : ICommandHandler<PlayCard>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IQueryDispatcher dispatcher;

        public SimplyRevealAndMove(ITimeProvider timeProvider, IQueryDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(PlayCard command, IEventDispatcher eventDispatcher)
        {
            if (command.Card == null)
                throw new Exception("No card selected");

            var card = dispatcher.Dispatch(new GetCard(command.Source, command.Card.Value));

            if (card == null)
                throw new Exception($"Card not found: {command.Card}");

            var revealEvent = new CardRevealed(timeProvider.Now, command.ProcessId, command.Source, card);
            eventDispatcher.Dispatch(revealEvent);
            
            if (command.Destination != null)
            {
                var moveEvent = new CardMoved(timeProvider.Now, command.ProcessId, command.Source, command.Destination, command.Card.Value);
                eventDispatcher.Dispatch(moveEvent);
            }
        }
    }
}
