using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CardOwnerSetObserver : IEventObserver<CardOwnerSet>
    {
        private readonly Game game;

        internal CardOwnerSetObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(CardOwnerSet @event)
        {
            game.SetCardOwner(@event.CardId, @event.PlayerIndex);
        }
    }
}
