using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Observers
{
    public class CardDrawnCounter : IEventObserver<CardDrawn>
    {
        private readonly PlayerCounter counter;
        private readonly IDispatcher dispatcher;

        public CardDrawnCounter(PlayerCounter drawCounter, IDispatcher dispatcher)
        {
            this.counter = drawCounter;
            this.dispatcher = dispatcher;
        }

        public void Invoke(CardDrawn @event)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player != null)
                counter.Aggregate(player.Index);
        }
    }
}
