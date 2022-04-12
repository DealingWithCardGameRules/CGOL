using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CardOwnerSetObserver : IEventObserver<CardOwnerSet>
    {
        private readonly Game game;

        public CardOwnerSetObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(CardOwnerSet @event)
        {
            game.SetCardOwner(@event.CardId, @event.PlayerIndex);
        }
    }
}
