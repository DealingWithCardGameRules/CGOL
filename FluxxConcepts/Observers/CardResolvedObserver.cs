using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Observers
{
    public class CardResolvedObserver : IEventObserver<CardResolved>
    {
        private readonly PlayerCounter playCounter;
        private readonly IDispatcher dispatcher;

        public CardResolvedObserver(PlayerCounter playCounter, IDispatcher dispatcher)
        {
            this.playCounter = playCounter ?? throw new System.ArgumentNullException(nameof(playCounter));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Invoke(CardResolved @event)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player != null)
                playCounter.Aggregate(player.Identity);
        }
    }
}
