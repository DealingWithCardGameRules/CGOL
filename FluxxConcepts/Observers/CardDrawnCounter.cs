using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Observers
{
    public class CardDrawnCounter : IEventObserver<CardDrawn>
    {
        private readonly DrawCounter counter;
        private readonly IDispatcher dispatcher;

        public CardDrawnCounter(DrawCounter counter, IDispatcher dispatcher)
        {
            this.counter = counter;
            this.dispatcher = dispatcher;
        }

        public void Invoke(CardDrawn @event)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            counter.Aggregate(player.Identity);
        }
    }
}
