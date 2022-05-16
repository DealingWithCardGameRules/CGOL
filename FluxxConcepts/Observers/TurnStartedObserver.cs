using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Observers
{
    public class TurnStartedObserver : IEventObserver<TurnStarted>
    {
        private readonly PlayerCounter[] counters;
        private readonly IDispatcher dispatcher;

        public TurnStartedObserver(IDispatcher dispatcher, params PlayerCounter[] counters)
        {
            this.counters = counters;
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Invoke(TurnStarted @event)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception($"No current player. Remember to set players using {nameof(SetPlayers)}");
            foreach (var counter in counters)
                counter.ResetPlayer(player.Index);
        }
    }
}
