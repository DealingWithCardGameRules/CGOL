using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class CardOwnerSetObserver : IEventObserver<CardOwnerSet>
    {
        private readonly Game game;

        internal CardOwnerSetObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task Invoke(CardOwnerSet @event)
        {
            game.SetCardOwner(@event.CardId, @event.PlayerIndex);
        }
    }
}
