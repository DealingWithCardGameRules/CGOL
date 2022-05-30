﻿using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Observers
{
    public class CardResolvedObserver : IEventObserver<CardResolved>
    {
        private readonly PlayerCounter playCounter;

        public CardResolvedObserver(PlayerCounter playCounter)
        {
            this.playCounter = playCounter ?? throw new System.ArgumentNullException(nameof(playCounter));
        }

        public void Invoke(CardResolved @event)
        {
            if (@event.Card.OwnerIndex.HasValue && @event.Card.OwnerIndex > 0)
                playCounter.Aggregate(@event.Card.OwnerIndex.Value);
        }
    }
}
