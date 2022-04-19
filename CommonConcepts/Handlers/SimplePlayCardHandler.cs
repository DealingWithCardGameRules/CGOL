﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplePlayCardHandler : ICommandHandler<PlayCard>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        private IPlayer? cachedPlayer;
        private IPlayer? Player
        { 
            get
            {
                if (cachedPlayer == null)
                    cachedPlayer = dispatcher.Dispatch(new CurrentPlayer());
                return cachedPlayer;
            }
        }

        public SimplePlayCardHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(PlayCard command, IEventDispatcher eventDispatcher)
        {
            var source = command.Source ?? CurrentPlayersHand();
            if (source == null)
                throw new ArgumentNullException($"No destination found, please specify one by filling out the \"from\" parameter or make sure the current player has a hand.");

            var selectedCard = command.Card ?? SelectCard(source);
            if (selectedCard == null)
                throw new Exception("No card selected!");

            var card = dispatcher.Dispatch(new GetCard(source, selectedCard.Value));

            if (card == null)
                throw new Exception($"Card not found: {command.Card}");

            var revealEvent = new CardRevealed(timeProvider.Now, command.ProcessId, source, card);
            eventDispatcher.Dispatch(revealEvent);

            var template = dispatcher.Dispatch(new GetTemplate(card.Template));
            if (template == null)
                return; // No instantanious effects to resolve

            foreach (ICommand effect in template.Instantaneous)
            {
                effect.SetAffactSelfRef(card.Instance);
                dispatcher.Dispatch(effect);
            }

            eventDispatcher.Dispatch(new CardResolved(timeProvider.Now, command.ProcessId, card));

            if (command.Destination != null)
            {
                var moveEvent = new CardMoved(timeProvider.Now, command.ProcessId, source, command.Destination, card.Instance);
                eventDispatcher.Dispatch(moveEvent);
            }
        }

        private Guid? SelectCard(string collection)
        {
            if (Player == null)
                throw new ArgumentException("No card select and no player to ask.");

            return dispatcher.Dispatch(new PickACard(collection, Player.Index));
        }

        private string? CurrentPlayersHand()
        {
            if (Player == null)
                throw new ArgumentException("No source specified, please fill out the the \"source\" parameter or specify players with individual hands");

            return dispatcher.Dispatch(new GetPlayersHand(Player.Index));
        }
    }
}