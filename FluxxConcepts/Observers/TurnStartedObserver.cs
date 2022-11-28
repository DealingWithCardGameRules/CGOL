using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Observers
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

        public async Task Invoke(TurnStarted @event)
        {
            var player = await dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception($"No current player. Remember to set players using {nameof(SetPlayers)}");
            foreach (var counter in counters)
                counter.ResetPlayer(player.Index);
        }
    }
}
