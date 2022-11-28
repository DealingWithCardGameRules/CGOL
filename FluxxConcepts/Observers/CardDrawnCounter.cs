using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

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

        public async Task Invoke(CardDrawn @event)
        {
            var player = await dispatcher.Dispatch(new CurrentPlayer());
            if (player != null)
                counter.Aggregate(player.Index);
        }
    }
}
